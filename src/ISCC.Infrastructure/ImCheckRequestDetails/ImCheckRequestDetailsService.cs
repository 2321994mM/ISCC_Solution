using ISCC.Application.ImCheckRequestDetails;
using ISCC.Application.ImCheckRequestDetails.Dtos;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.ImCheckRequestDetails;

/// <summary>
/// EF Core port of the legacy <c>Im_CheckRequestDetailsBLL</c> ("تفاصيل طلب الفحص - وارد").
/// </summary>
/// <remarks>
/// <para>
/// The legacy BLL fired hundreds of tiny per-row queries (one per item, per lot, per
/// reference name). This port loads each collection once and resolves display names from
/// in-memory dictionaries, so a page that used to issue N+1 queries now issues a fixed,
/// small number. Business rules, languages and the "تم الدفع / لم يتم الدفع" wording mirror
/// the legacy SQL and C# exactly.
/// </para>
/// <para>
/// Two legacy bugs were corrected where reproducing them would silently break the screen:
/// the shift/sample "paid" lookups compared <c>Fees_Transactions.Table_ID</c> to a DTO
/// property that was never assigned (always 0); this port compares it to the actual request
/// id. And the permission-attachment list was overwritten in a loop, keeping only the last
/// permission's attachments; this port accumulates all of them.
/// </para>
/// </remarks>
public class ImCheckRequestDetailsService : IImCheckRequestDetailsService
{
    private const short UserTypeId = 127;
    private const short TypeLogId = 135;

    private readonly PlantQuarantineDbContext _db;

    public ImCheckRequestDetailsService(PlantQuarantineDbContext db)
    {
        _db = db;
    }

    private static bool IsArabic =>
        System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            .StartsWith("ar", StringComparison.OrdinalIgnoreCase);

    private static string? Pick(string? arabic, string? english) =>
        IsArabic ? arabic ?? english : english ?? arabic;

    // Every sequence in PlantQuarantine_New is bigint, so the value must be read back as
    // long. Reading it as decimal throws InvalidCastException (Int64 -> Decimal) the moment
    // the reader materialises the row.
    private decimal NextSequenceValue(string sequence) =>
        _db.Database
            .SqlQueryRaw<long>($"SELECT NEXT VALUE FOR dbo.{sequence} AS value")
            .AsEnumerable()
            .First();

    private void AddLog(short action, long actionValue, long requestId, string notes, short? userId)
    {
        _db.TableActionLogCheckRequests.Add(new TableActionLogCheckRequest
        {
            Id = (long)NextSequenceValue("Table_Action_Log_CheckRequest_SEQ"),
            IdTableAction = action,
            IdTableActionValue = actionValue,
            ImCheckRequestId = requestId,
            Nots = notes,
            UserCreationId = userId,
            UserCreationDate = DateTime.Now,
            UserTypeId = UserTypeId,
            TypeLogId = TypeLogId,
        });
    }

    /// <inheritdoc />
    public async Task<ImRequestDetailsDto?> GetAsync(
        string imCheckRequestNumber,
        int? outletId,
        CancellationToken cancellationToken)
    {
        var request = await _db.ImCheckRequests.AsNoTracking()
            .Where(x => x.CheckRequestNumber == imCheckRequestNumber)
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (request is null)
            return null;

        var data = await _db.ImCheckRequestData.AsNoTracking()
            .FirstOrDefaultAsync(x => x.ImCheckRequestId == request.Id, cancellationToken);

        if (data is null)
            return null;

        var dto = new ImRequestDetailsDto
        {
            Im_CheckRequest_ID = request.Id,
            IsAccepted = request.IsAccepted,
            IsActive = request.IsActive,
            IsPaid = request.IsPaid,
            Im_CheckRequestData_ID = data.Id,
            ImCheckRequest_Number = request.CheckRequestNumber,
            Ship_Name = data.ShipName,
            Importer_ID = data.ImporterId,
            ImporterType_Id = data.ImporterTypeId,
            Transport_Mean_Id = data.TransportMeanId,
            InternationalTransport_Id = data.InternationalTransportationId,
            Shipment_Mean_Id = data.ShipmentMeanId,
            TransitCountryId = data.TransitCountryId,
            MessageOwner = data.DelegateName,
            MessageOwnerNationalID = data.DelegateAddress,
        };

        // الدولة المصدرة
        dto.ExportCountryName = await _db.Countries.AsNoTracking()
            .Where(c => c.Id == data.ExportCountryId)
            .Select(c => IsArabic ? c.ArName : c.EnName)
            .FirstOrDefaultAsync(cancellationToken);

        // المنفذ
        if (outletId != null && request.OutletId != null)
        {
            dto.outletName = await _db.Outlets.AsNoTracking()
                .Where(o => o.Id == request.OutletId)
                .Select(o => o.ArName)
                .FirstOrDefaultAsync(cancellationToken) ?? string.Empty;
        }
        else
        {
            dto.outletName = string.Empty;
        }

        // وسائل الشحن/النقل والدولية
        if (dto.Shipment_Mean_Id != null)
        {
            dto.Shipment_MeanName = await _db.ShipmentMeans.AsNoTracking()
                .Where(s => s.Id == dto.Shipment_Mean_Id)
                .Select(s => s.ArName)
                .FirstOrDefaultAsync(cancellationToken);
        }

        if (dto.Transport_Mean_Id != null)
        {
            dto.Transport_MeanName = await _db.TransportMeans.AsNoTracking()
                .Where(t => t.Id == dto.Transport_Mean_Id)
                .Select(t => t.ArName)
                .FirstOrDefaultAsync(cancellationToken);
        }

        if (dto.InternationalTransport_Id != null)
        {
            dto.InternationalTransport = await _db.InternationalTransportations.AsNoTracking()
                .Where(t => t.Id == dto.InternationalTransport_Id)
                .Select(t => IsArabic ? t.ArName : t.EnName)
                .FirstOrDefaultAsync(cancellationToken);
        }

        await LoadImporterAsync(dto, cancellationToken);
        await LoadFeesAsync(dto, request, cancellationToken);
        await LoadShippingAndLotsAsync(dto, request, cancellationToken);
        await LoadPortsAsync(dto, data, cancellationToken);
        await LoadAttachmentsAsync(dto, request, cancellationToken);
        await LoadCustomsAsync(dto, request, cancellationToken);

        return dto;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<RefuseReasonOptionDto>> GetRefuseReasonsAsync(
        int refuse,
        CancellationToken cancellationToken)
    {
        var query = _db.RefuseReasons.AsNoTracking()
            .Where(r => r.UserDeletionId == null && r.IsActive && (r.IsExport == 81 || r.IsExport == 82));

        query = refuse == 1
            ? query.Where(r => r.RefusedStopped == 84)
            : query.Where(r => r.RefusedStopped == 83);

        var options = await query
            .Select(r => new RefuseReasonOptionDto
            {
                DisplayText = IsArabic ? r.NameAr : r.NameEn,
                Value = r.Id,
            })
            .OrderBy(r => r.DisplayText)
            .ToListAsync(cancellationToken);

        options.Insert(0, new RefuseReasonOptionDto { DisplayText = "----------", Value = null });
        return options;
    }

    /// <inheritdoc />
    public async Task<long> SaveReasonsAsync(ReasonsListReqIdDto dto, CancellationToken cancellationToken)
    {
        await using var tx = await _db.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            foreach (var reasonId in dto.refuseReasonsIds)
            {
                _db.ImCheckRequestRefuseReasons.Add(new ImCheckRequestRefuseReason
                {
                    Id = (long)NextSequenceValue("Im_CheckRequest_RefuseReason_seq"),
                    ImCheckRequestId = dto.checkReqId,
                    RefuseReasonId = reasonId,
                    UserCreationId = dto.User_Creation_Id,
                    UserCreationDate = dto.User_Creation_Date == default ? DateTime.Now : dto.User_Creation_Date,
                });
            }

            await _db.SaveChangesAsync(cancellationToken);
            await tx.CommitAsync(cancellationToken);
            return dto.checkReqId;
        }
        catch
        {
            await tx.RollbackAsync(cancellationToken);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task AcceptRequestAsync(ImCheckRequestDto dto, CancellationToken cancellationToken)
    {
        await using var tx = await _db.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var request = await _db.ImCheckRequests.FirstOrDefaultAsync(x => x.Id == dto.ID, cancellationToken)
                ?? throw new InvalidOperationException($"Check request {dto.ID} was not found.");

            request.IsAccepted = dto.IsAccepted;
            request.IsAcceptedDate = dto.IsAccepted_Date ?? DateTime.Now;
            request.IsActive = dto.IsActive;
            request.UserUpdationId = dto.User_Updation_Id;
            request.UserUpdationDate = dto.User_Updation_Date ?? DateTime.Now;

            if (dto.IsAccepted == true)
            {
                AddLog(12, request.Id, request.Id, " تم الموافقة علي الطلب ", dto.User_Updation_Id);
            }
            else
            {
                AddLog(23, request.Id, request.Id, " تم رفض الطلب  ", dto.User_Updation_Id);
            }

            await _db.SaveChangesAsync(cancellationToken);
            await tx.CommitAsync(cancellationToken);
        }
        catch
        {
            await tx.RollbackAsync(cancellationToken);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task SaveItemFeesAsync(ItemFeesDto item, CancellationToken cancellationToken)
    {
        if (item.ImcheckReqItem_ID is null)
            return;

        await using var tx = await _db.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _db.ImCheckRequestItems
                .FirstOrDefaultAsync(x => x.Id == item.ImcheckReqItem_ID.Value, cancellationToken)
                ?? throw new InvalidOperationException($"Check request item {item.ImcheckReqItem_ID} was not found.");

            entity.Fees = item.Fees;

            // The legacy endpoint logged against the parent request; resolve it via the shipping method.
            var requestId = await _db.ImCheckRequsetShippingMethods.AsNoTracking()
                .Where(s => s.Id == entity.ImCheckRequsetShippingMethodId)
                .Select(s => s.ImCheckRequestId ?? 0)
                .FirstOrDefaultAsync(cancellationToken);

            AddLog(15, entity.Id, requestId, " تعديل رسوم النبات من خلال الحجر الزراعي", item.User_Updation_Id);

            await _db.SaveChangesAsync(cancellationToken);
            await tx.CommitAsync(cancellationToken);
        }
        catch
        {
            await tx.RollbackAsync(cancellationToken);
            throw;
        }
    }

    // ----- importer (company / public organization / person) -----

    private async Task LoadImporterAsync(ImRequestDetailsDto dto, CancellationToken cancellationToken)
    {
        if (dto.ImporterType_Id == 6)
        {
            var company = await _db.CompanyNationals.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == dto.Importer_ID, cancellationToken);

            if (company != null)
            {
                dto.ImporterType = "شركة";
                dto.ImporterName = Pick(company.NameAr, company.NameEn);
                dto.ImporterAddress = Pick(company.AddressAr, company.AddressEn);
                dto.OwnerName = Pick(company.OwnerAr, company.OwnerEn);
            }

            var activityRows = await _db.CompanyActivities.AsNoTracking()
                .Where(ca => ca.CompanyId == dto.Importer_ID && ca.IsActive)
                .Select(ca => new
                {
                    ca.MainActivityTypeNavigation.ValueName,
                    ca.MainActivityTypeNavigation.ValueNameEn,
                    ca.EnrollmentName,
                    ca.EnrollmentNumber,
                    ca.EnrollmentStart,
                    ca.EnrollmentEnd,
                    ca.EnrollmentType!.ArName,
                    ca.EnrollmentType!.EnName,
                })
                .ToListAsync(cancellationToken);

            dto._CompanyActivitys = activityRows.Select(ca => new CompanyActivityDto
            {
                CompActivityType__Name = Pick(ca.ValueName, ca.ValueNameEn),
                Enrollment_Name = ca.EnrollmentName,
                Enrollment_Number = ca.EnrollmentNumber,
                Enrollment_Start = ca.EnrollmentStart?.ToDateTime(TimeOnly.MinValue),
                Enrollment_End = ca.EnrollmentEnd?.ToDateTime(TimeOnly.MinValue),
                Enrollment_type_Name = Pick(ca.ArName, ca.EnName),
            }).ToList();

            dto.ImporterContacts = await _db.ExContactData.AsNoTracking()
                .Where(a => a.ExporterId == dto.Importer_ID && a.ExporterTypeId == 6)
                .Select(a => new ContactTypeDto
                {
                    Name_Ar = IsArabic ? a.ContactType.NameAr : a.ContactType.NameEn,
                    Value = a.Value,
                })
                .ToListAsync(cancellationToken);
        }
        else if (dto.ImporterType_Id == 7)
        {
            var org = await _db.PublicOrganizations.AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == dto.Importer_ID, cancellationToken);

            if (org != null)
            {
                dto.ImporterName = Pick(org.NameAr, org.NameEn);
                dto.ImporterAddress = Pick(org.AddressAr, org.AddressEn);
                dto.ImporterType = "هيئة";
            }

            var activityRows = await _db.PublicOrganizations.AsNoTracking()
                .Where(o => o.Id == dto.Importer_ID && o.IsActive == true)
                .Select(o => new
                {
                    o.NameAr,
                    o.PersonResponsibleIdnumber,
                    o.PersonResponsibleName,
                    o.PersonResponsibleJob,
                    o.PersonResponsibleAddress,
                    o.UserActivationDate,
                })
                .ToListAsync(cancellationToken);

            dto._CompanyActivitys = activityRows.Select(o => new CompanyActivityDto
            {
                Enrollment_Name = o.NameAr,
                PersonResponsible_IDNumber = o.PersonResponsibleIdnumber,
                PersonResponsible_Name = o.PersonResponsibleName,
                Person_Responsible_Job = o.PersonResponsibleJob,
                Person_Responsible_Address = o.PersonResponsibleAddress,
                Enrollment_Start = o.UserActivationDate,
            }).ToList();

            dto.ImporterContacts = await _db.ExContactData.AsNoTracking()
                .Where(a => a.ExporterId == dto.Importer_ID && a.ExporterTypeId == 7)
                .Select(a => new ContactTypeDto
                {
                    Name_Ar = IsArabic ? a.ContactType.NameAr : a.ContactType.NameEn,
                    Value = a.Value,
                })
                .ToListAsync(cancellationToken);
        }
        else
        {
            var person = await _db.People.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == dto.Importer_ID, cancellationToken);

            if (person != null)
            {
                dto.ImporterName = person.Name;
                dto.ImporterAddress = person.Address;
                dto.ImporterType = "فرد";

                dto.ImporterContacts = new List<ContactTypeDto>
                {
                    new() { Name_Ar = person.Email, Value = person.Phone },
                };
            }

            dto._CompanyActivitys = new List<CompanyActivityDto>();
        }

        // الشركات خارج مصر
        dto.ImportersCompanies = await _db.ImCheckRequestDataExtras.AsNoTracking()
            .Where(v => v.ImCheckRequestDataId == dto.Im_CheckRequestData_ID)
            .Select(v => new ImporterCompanyDto
            {
                ImporterCompany = v.ImportCompany,
                ImporterCompanyAddress = v.ImporeterCompanyAddress,
                ImporterCompanyEn = v.ImportCompanyEn,
                ImporterCompanyAddressEn = v.ImporeterCompanyAddressEn,
            })
            .ToListAsync(cancellationToken);
    }

    // ----- fees: items, shifts, samples, treatments -----

    private async Task LoadFeesAsync(
        ImRequestDetailsDto dto,
        ImCheckRequest request,
        CancellationToken cancellationToken)
    {
        var committees = await _db.ImRequestCommittees.AsNoTracking()
            .Where(c => c.ImCheckRequestId == request.Id)
            .Select(c => new { c.Id, c.CommitteeTypeId, c.Status })
            .ToListAsync(cancellationToken);

        var committeeIds = committees.Select(c => c.Id).ToList();

        // رسوم النبات
        var feeItems = await _db.ImCheckRequestItems.AsNoTracking()
            .Where(i => i.ItemPermissionNumber == request.CheckRequestNumber)
            .Select(i => new
            {
                i.Id,
                i.ItemShortNameId,
                i.Fees,
                i.GrossWeight,
                i.NetWeight,
            })
            .ToListAsync(cancellationToken);

        var shortNameIds = feeItems.Where(i => i.ItemShortNameId != null).Select(i => i.ItemShortNameId!.Value).Distinct().ToList();
        var shortNames = await _db.ItemShortNames.AsNoTracking()
            .Where(s => shortNameIds.Contains(s.Id))
            .Select(s => new { s.Id, s.ItemId, s.ShortNameAr, s.ShortNameEn })
            .ToDictionaryAsync(s => s.Id, cancellationToken);

        var itemIds = shortNames.Values.Where(s => s.ItemId != null).Select(s => s.ItemId!.Value).Distinct().ToList();
        var itemNames = await _db.Items.AsNoTracking()
            .Where(i => itemIds.Contains(i.Id))
            .Select(i => new { i.Id, i.NameAr, i.NameEn })
            .ToDictionaryAsync(i => i.Id, cancellationToken);

        dto.Fees_Item_All = feeItems.Select(i =>
        {
            var isn = i.ItemShortNameId != null ? shortNames.GetValueOrDefault(i.ItemShortNameId.Value) : null;
            var it = isn?.ItemId != null ? itemNames.GetValueOrDefault(isn.ItemId.Value) : null;
            return new FeesItemDto
            {
                ID = i.Id,
                ItemShortName = Pick(isn?.ShortNameAr, isn?.ShortNameEn),
                ItemName = Pick(it?.NameAr, it?.NameEn),
                Fees = i.Fees,
                GrossWeight = i.GrossWeight / 1000m,
                Net_Weight = i.NetWeight,
                Is_Paid_Items = request.IsPaid == true ? "تم الدفع" : "لم يتم الدفع ",
            };
        }).ToList();

        // رسم النوبتجية
        var shifts = await _db.ImRequestCommitteeShifts.AsNoTracking()
            .Where(s => committeeIds.Contains(s.ImRequestCommitteeId))
            .Select(s => new { s.Id, s.Amount, s.Count, s.ShiftTimingId })
            .ToListAsync(cancellationToken);

        dto.Fees_Item_Shift_All = shifts.Select(s => new FeesItemShiftDto
        {
            Amount_Per_Shift = s.Amount,
            Count_Per_Shift = s.Count,
            total_Per_Shift = (decimal?)s.Count * s.Amount,
        }).ToList();

        dto.Shift_Item_All = dto.Fees_Item_Shift_All.Sum(s => s.total_Per_Shift);

        var shiftTimings = await _db.ShiftTimings.AsNoTracking()
            .Where(t => shifts.Select(x => x.ShiftTimingId).Contains(t.Id))
            .Select(t => new { t.Id, t.NameAr, t.NameEn })
            .ToDictionaryAsync(t => t.Id, cancellationToken);

        var paidShiftIds = await _db.FeesTransactionsDetiles.AsNoTracking()
            .Where(f => f.ShiftId != null && f.FeesTransactions!.TableNameId == 4 && f.FeesTransactions.TableId == request.Id)
            .Select(f => f.ShiftId!.Value)
            .Distinct()
            .ToListAsync(cancellationToken);

        dto.List_Shift = shifts.Select(s => new ListShiftDto
        {
            ID = s.Id,
            Shift_Name = shiftTimings.TryGetValue(s.ShiftTimingId, out var t) ? Pick(t.NameAr, t.NameEn) : null,
            Shift_Count = s.Count,
            Shift_Amount = s.Amount,
            Shift_Sum_All = (decimal?)s.Count * s.Amount,
            Is_Paid_Shift = paidShiftIds.Contains(s.Id) ? "تم الدفع" : null,
        }).ToList();

        // رسوم السحب
        var samples = await _db.ImCheckRequestSampleData.AsNoTracking()
            .Where(s => committeeIds.Contains(s.ImRequestCommitteeId))
            .Select(s => new { s.Id, s.SampleBarCode, s.IsTotal, s.AnalysisLabTypeId })
            .ToListAsync(cancellationToken);

        var labTypeIds = samples.Select(s => s.AnalysisLabTypeId).Distinct().ToList();
        var labTypes = await _db.AnalysisLabTypes.AsNoTracking()
            .Where(t => labTypeIds.Contains(t.Id))
            .Select(t => new { t.Id, t.AnalysisLabId, t.AnalysisTypeId })
            .ToDictionaryAsync(t => t.Id, cancellationToken);

        var labIds = labTypes.Values.Select(t => t.AnalysisLabId).Distinct().ToList();
        var labs = await _db.AnalysisLabs.AsNoTracking()
            .Where(l => labIds.Contains(l.Id))
            .Select(l => new { l.Id, l.NameAr, l.NameEn })
            .ToDictionaryAsync(l => l.Id, cancellationToken);

        var analysisTypeIds = labTypes.Values.Select(t => t.AnalysisTypeId).Distinct().ToList();
        var analysisTypes = await _db.AnalysisTypes.AsNoTracking()
            .Where(a => analysisTypeIds.Contains(a.Id))
            .Select(a => new { a.Id, a.NameAr, a.NameEn })
            .ToDictionaryAsync(a => a.Id, cancellationToken);

        var paidSampleIds = await _db.FeesTransactionsDetiles.AsNoTracking()
            .Where(f => f.SampleDataId != null && f.FeesTransactions!.TableNameId == 4 && f.FeesTransactions.TableId == request.Id)
            .Select(f => f.SampleDataId!.Value)
            .Distinct()
            .ToListAsync(cancellationToken);

        dto.List_Sample = samples
            .Select(s =>
            {
                var labType = labTypes.GetValueOrDefault(s.AnalysisLabTypeId);
                var lab = labType != null ? labs.GetValueOrDefault(labType.AnalysisLabId) : null;
                var analysisType = labType != null ? analysisTypes.GetValueOrDefault(labType.AnalysisTypeId) : null;
                return new ListSampleDto
                {
                    ID = s.Id,
                    Sample_BarCode = s.SampleBarCode,
                    Laboratory_Name = Pick(lab?.NameAr, lab?.NameEn),
                    Sample_Name = Pick(analysisType?.NameAr, analysisType?.NameEn),
                    Is_Total = s.IsTotal == false ? "جزئي" : "كلي",
                    Sample_Count = 1,
                    Sample_Amount = 200,
                    Sample_Sum_All = 200,
                    Is_Paid_Sample = paidSampleIds.Contains(s.Id) ? "تم الدفع" : null,
                };
            })
            .GroupBy(s => s.Sample_BarCode)
            .Select(g => g.First())
            .ToList();

        // رسوم المعالجة (لجان النوع 14 والمكتملة فقط)
        var treatmentCommitteeIds = committees
            .Where(c => c.CommitteeTypeId == 14 && c.Status == true)
            .Select(c => c.Id)
            .ToList();

        var treatments = await _db.ImRequestTreatmentData.AsNoTracking()
            .Where(t => treatmentCommitteeIds.Contains(t.ImRequestCommitteeId))
            .Select(t => new { t.Id, t.TreatmentMethodId, t.TreatmentTypeId, t.TreatmentMatId, t.Amount })
            .ToListAsync(cancellationToken);

        var methodIds = treatments.Select(t => (byte)t.TreatmentMethodId).Distinct().ToList();
        var methods = await _db.TreatmentMethods.AsNoTracking()
            .Where(m => methodIds.Contains(m.Id))
            .Select(m => new { m.Id, m.ArName, m.EnName })
            .ToDictionaryAsync(m => m.Id, cancellationToken);

        var typeIds = treatments.Where(t => t.TreatmentTypeId != null).Select(t => t.TreatmentTypeId!.Value).Distinct().ToList();
        var types = await _db.TreatmentTypes.AsNoTracking()
            .Where(t => typeIds.Contains(t.Id))
            .Select(t => new { t.Id, t.ArName, t.EnName })
            .ToDictionaryAsync(t => t.Id, cancellationToken);

        var matIds = treatments.Where(t => t.TreatmentMatId != null).Select(t => t.TreatmentMatId!.Value).Distinct().ToList();
        var mats = await _db.TreatmentMaterials.AsNoTracking()
            .Where(m => matIds.Contains(m.Id))
            .Select(m => new { m.Id, m.ItemId })
            .ToDictionaryAsync(m => m.Id, cancellationToken);

        var matItemIds = mats.Values.Where(m => m.ItemId != null).Select(m => m.ItemId!.Value).Distinct().ToList();
        var matItems = await _db.Items.AsNoTracking()
            .Where(i => matItemIds.Contains(i.Id))
            .Select(i => new { i.Id, i.NameAr, i.NameEn })
            .ToDictionaryAsync(i => i.Id, cancellationToken);

        var paidTreatmentIds = await _db.FeesTransactionsDetiles.AsNoTracking()
            .Where(f => f.TreatmentDataId != null)
            .Select(f => f.TreatmentDataId!.Value)
            .Distinct()
            .ToListAsync(cancellationToken);

        dto.List_Treatment = treatments.Select(t =>
        {
            var mat = t.TreatmentMatId != null ? mats.GetValueOrDefault(t.TreatmentMatId.Value) : null;
            var matItem = mat?.ItemId != null ? matItems.GetValueOrDefault(mat.ItemId.Value) : null;
            return new ListTreatmentDto
            {
                ID = t.Id,
                TreatmentMethod_Name = methods.TryGetValue(t.TreatmentMethodId, out var m) ? Pick(m.ArName, m.EnName) : null,
                TreatmentType_Name = t.TreatmentTypeId != null && types.TryGetValue(t.TreatmentTypeId.Value, out var ty) ? Pick(ty.ArName, ty.EnName) : null,
                TreatmentMat_Name = Pick(matItem?.NameAr, matItem?.NameEn),
                Treatment_Amount = t.Amount,
                Is_Paid_Treatment = paidTreatmentIds.Contains(t.Id) ? "تم الدفع" : null,
            };
        }).ToList();

        var itemFeesTotal = dto.Fees_Item_All.Sum(a => a.Fees) ?? 0m;
        var sumSamples = dto.List_Sample.Sum(c => c.Sample_Sum_All) ?? 0m;
        dto.SUM_Shift_Fees_Item = 10 + (dto.Shift_Item_All ?? 0m) + itemFeesTotal + sumSamples;
    }

    // ----- shipping methods, their items and lots, and constrains -----

    private async Task LoadShippingAndLotsAsync(
        ImRequestDetailsDto dto,
        ImCheckRequest request,
        CancellationToken cancellationToken)
    {
        var shippingMethods = await _db.ImCheckRequsetShippingMethods.AsNoTracking()
            .Where(s => s.ImCheckRequestId == request.Id)
            .ToListAsync(cancellationToken);

        var containerCodes = await _db.ASystemCodes.AsNoTracking()
            .Where(c => (c.SystemCodeTypeId == 28 || c.SystemCodeTypeId == 29))
            .Select(c => new { c.Id, c.SystemCodeTypeId, c.ValueName, c.ValueNameEn })
            .ToListAsync(cancellationToken);

        var shippingIds = shippingMethods.Select(s => s.Id).ToList();

        var items = await _db.ImCheckRequestItems.AsNoTracking()
            .Where(i => i.ImCheckRequsetShippingMethodId != null && shippingIds.Contains(i.ImCheckRequsetShippingMethodId.Value))
            .ToListAsync(cancellationToken);

        var itemIds = items.Select(i => i.Id).ToList();
        var lots = await _db.ImCheckRequestItemsLotCategories.AsNoTracking()
            .Where(l => l.ImCheckRequestItemsId != null && itemIds.Contains(l.ImCheckRequestItemsId.Value))
            .ToListAsync(cancellationToken);

        // reference lookups
        var shortNameIds = items.Where(i => i.ItemShortNameId != null).Select(i => i.ItemShortNameId!.Value).Distinct().ToList();
        var shortNames = await _db.ItemShortNames.AsNoTracking()
            .Where(s => shortNameIds.Contains(s.Id))
            .Select(s => new { s.Id, s.ItemId, s.ShortNameAr, s.ShortNameEn, s.ItemStatusId, s.ItemPurposeId, s.SubPartId })
            .ToDictionaryAsync(s => s.Id, cancellationToken);

        var referencedItemIds = shortNames.Values.Where(s => s.ItemId != null).Select(s => s.ItemId!.Value).Distinct().ToList();
        var referencedItems = await _db.Items.AsNoTracking()
            .Where(i => referencedItemIds.Contains(i.Id))
            .Select(i => new { i.Id, i.NameAr, i.NameEn, i.ScientificName })
            .ToDictionaryAsync(i => i.Id, cancellationToken);

        var statusIds = shortNames.Values.Where(s => s.ItemStatusId != null).Select(s => s.ItemStatusId!.Value).Distinct().ToList();
        var statuses = await _db.ItemStatuses.AsNoTracking()
            .Where(s => statusIds.Contains(s.Id))
            .Select(s => new { s.Id, s.ArName, s.EnName })
            .ToDictionaryAsync(s => s.Id, cancellationToken);

        var purposeIds = shortNames.Values.Where(s => s.ItemPurposeId != null).Select(s => s.ItemPurposeId!.Value).Distinct().ToList();
        var purposes = await _db.ItemPurposes.AsNoTracking()
            .Where(p => purposeIds.Contains(p.Id))
            .Select(p => new { p.Id, p.ArName, p.EnName })
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        var subPartIds = shortNames.Values.Where(s => s.SubPartId != null).Select(s => s.SubPartId!.Value).Distinct().ToList();
        var subParts = await _db.SubParts.AsNoTracking()
            .Where(s => subPartIds.Contains(s.Id))
            .Select(s => new { s.Id, s.NameAr, s.NameEn })
            .ToDictionaryAsync(s => s.Id, cancellationToken);

        var initiatorIds = items.Where(i => i.ImInitiatorId != null).Select(i => i.ImInitiatorId!.Value).Distinct().ToList();
        var initiators = await _db.ImInitiators.AsNoTracking()
            .Where(i => initiatorIds.Contains(i.Id))
            .Select(i => new { i.Id, i.CountryId, i.ItemShortNameId, i.QualitativeGroupId })
            .ToDictionaryAsync(i => i.Id, cancellationToken);

        var initiatorCountryIds = initiators.Values.Where(i => i.CountryId != null).Select(i => i.CountryId!.Value).Distinct().ToList();
        var countries = await _db.Countries.AsNoTracking()
            .Where(c => initiatorCountryIds.Contains(c.Id))
            .Select(c => new { c.Id, c.ArName, c.EnName })
            .ToDictionaryAsync(c => c.Id, cancellationToken);

        var qualGroupIds = initiators.Values.Where(i => i.QualitativeGroupId != null).Select(i => i.QualitativeGroupId!.Value).Distinct().ToList();
        var qualGroups = await _db.QualitativeGroups.AsNoTracking()
            .Where(g => qualGroupIds.Contains(g.Id))
            .Select(g => new { g.Id, g.NameAr, g.NameEn })
            .ToDictionaryAsync(g => g.Id, cancellationToken);

        var packageTypeIds = items.Where(i => i.PackageTypeId != null).Select(i => i.PackageTypeId!.Value)
            .Concat(lots.Where(l => l.PackageTypeId != null).Select(l => l.PackageTypeId!.Value)).Distinct().ToList();
        var packageTypes = await _db.PackageTypes.AsNoTracking()
            .Where(p => packageTypeIds.Contains(p.Id))
            .Select(p => new { p.Id, p.ArName, p.EnName })
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        var packageMaterialIds = items.Where(i => i.PackageMaterialId != null).Select(i => i.PackageMaterialId!.Value)
            .Concat(lots.Where(l => l.PackageMaterialId != null).Select(l => l.PackageMaterialId!.Value)).Distinct().ToList();
        var packageMaterials = await _db.PackageMaterials.AsNoTracking()
            .Where(p => packageMaterialIds.Contains(p.Id))
            .Select(p => new { p.Id, p.ArName, p.EnName })
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        var categoryIds = lots.Where(l => l.ItemCategoryId != null).Select(l => l.ItemCategoryId!.Value).Distinct().ToList();
        var categories = await _db.ItemCategories.AsNoTracking()
            .Where(c => categoryIds.Contains(c.Id))
            .Select(c => new { c.Id, c.NameAr, c.NameEn, c.IsRegister, c.ItemCategoriesGroupId })
            .ToDictionaryAsync(c => c.Id, cancellationToken);

        var categoryGroupIds = categories.Values.Where(c => c.ItemCategoriesGroupId != null).Select(c => c.ItemCategoriesGroupId!.Value).Distinct().ToList();
        var categoryGroups = await _db.ItemCategoriesGroups.AsNoTracking()
            .Where(g => categoryGroupIds.Contains(g.Id))
            .Select(g => new { g.Id, g.NameAr, g.NameEn })
            .ToDictionaryAsync(g => g.Id, cancellationToken);

        // constrains per initiator
        var constrainsByInitiator = await BuildConstrainsAsync(initiatorIds, cancellationToken);

        var itemsByShipping = items.GroupBy(i => i.ImCheckRequsetShippingMethodId!.Value)
            .ToDictionary(g => g.Key, g => g.ToList());

        dto.checkRequestShipping = shippingMethods.Select(ship =>
        {
            var container = containerCodes.FirstOrDefault(c => c.Id == ship.ContainersId && c.SystemCodeTypeId == 28);
            var containerType = containerCodes.FirstOrDefault(c => c.Id == ship.ContainersTypeId && c.SystemCodeTypeId == 29);

            var shipDto = new CheckRequestShippingDto
            {
                ID = ship.Id,
                Im_CheckRequest_ID = ship.ImCheckRequestId,
                containers_ID = ship.ContainersId,
                containers_type_ID = ship.ContainersTypeId,
                ShipholdNumber = ship.ShipholdNumber,
                ContainerNumber = ship.ContainerNumber,
                NavigationalNumber = ship.NavigationalNumber,
                Total_Weight = ship.TotalWeight,
                containerName = Pick(container?.ValueName, container?.ValueNameEn),
                containerType = Pick(containerType?.ValueName, containerType?.ValueNameEn),
            };

            if (!itemsByShipping.TryGetValue(ship.Id, out var shipItems))
                return shipDto;

            foreach (var item in shipItems)
            {
                var isn = item.ItemShortNameId != null ? shortNames.GetValueOrDefault(item.ItemShortNameId.Value) : null;
                var it = isn?.ItemId != null ? referencedItems.GetValueOrDefault(isn.ItemId.Value) : null;
                var initiator = item.ImInitiatorId != null ? initiators.GetValueOrDefault(item.ImInitiatorId.Value) : null;
                var initiatorCountry = initiator?.CountryId != null ? countries.GetValueOrDefault(initiator.CountryId.Value) : null;

                var itemDto = new ItemsCheckReqDto
                {
                    ID = item.Id,
                    Item_ShortName_ID = item.ItemShortNameId,
                    Im_Initiator_ID = item.ImInitiatorId,
                    ImcheckReqItem_ID = item.Id,
                    ImcheckReqshippedMethod_ID = item.ImCheckRequsetShippingMethodId,
                    Size = item.Size,
                    Package_Count = item.PackageCount,
                    Package_Weight = item.PackageWeight,
                    Units_Number = item.UnitsNumber,
                    packageTypeID = item.PackageTypeId,
                    packageMaterialID = item.PackageMaterialId,
                    GrossWeight = item.GrossWeight,
                    Net_Weight = item.NetWeight,
                    Fees = item.Fees,
                    Order_TextItem = item.OrderText,
                    ItemShortNameAr = isn?.ShortNameAr,
                    ItemShortNameEn = isn?.ShortNameEn,
                    ItemName = Pick(it?.NameAr, it?.NameEn),
                    ScientificNameAr = it?.ScientificName,
                    InitiatorCountry = Pick(initiatorCountry?.ArName, initiatorCountry?.EnName),
                    Status = isn?.ItemStatusId != null && statuses.TryGetValue(isn.ItemStatusId.Value, out var st) ? Pick(st.ArName, st.EnName) : null,
                    Purpose = isn?.ItemPurposeId != null && purposes.TryGetValue(isn.ItemPurposeId.Value, out var pu) ? Pick(pu.ArName, pu.EnName) : null,
                    subPartName = isn?.SubPartId != null && subParts.TryGetValue(isn.SubPartId.Value, out var sp) ? Pick(sp.NameAr, sp.NameEn) : null,
                    SubPart_id = isn?.SubPartId,
                    packageType = item.PackageTypeId != null && packageTypes.TryGetValue(item.PackageTypeId.Value, out var pt) ? Pick(pt.ArName, pt.EnName) : null,
                    packageMaterial = item.PackageMaterialId != null && packageMaterials.TryGetValue(item.PackageMaterialId.Value, out var pm) ? Pick(pm.ArName, pm.EnName) : null,
                    Itemconstrains = item.ImInitiatorId != null ? constrainsByInitiator.GetValueOrDefault(item.ImInitiatorId.Value) : null,
                };

                itemDto.ItemCategories_lots = lots
                    .Where(l => l.ImCheckRequestItemsId == item.Id)
                    .Select(l =>
                    {
                        var cat = l.ItemCategoryId != null ? categories.GetValueOrDefault(l.ItemCategoryId.Value) : null;
                        var group = cat?.ItemCategoriesGroupId != null ? categoryGroups.GetValueOrDefault(cat.ItemCategoriesGroupId.Value) : null;
                        return new CategoriesLotsDto
                        {
                            ID = l.Id,
                            Im_checkReqItems_ID = l.ImCheckRequestItemsId,
                            ItemCategory_ID = l.ItemCategoryId,
                            Size = l.Size,
                            Package_Count = l.PackageCount,
                            Package_Weight = l.PackageWeight,
                            Units_Number = l.UnitsNumber,
                            packageTypeID = l.PackageTypeId,
                            Order_TextLot = l.OrderText,
                            packageMaterialID = l.PackageMaterialId,
                            Lot_Number = l.LotNumber,
                            Grower_Number = l.GrowerNumber,
                            Waybill = l.Waybill,
                            Number_Wooden_Package = l.NumberWoodenPackage,
                            GrossWeight = l.GrossWeight,
                            Net_Weight = l.NetWeight,
                            Package_Based_Weight = l.PackageBasedWeight,
                            Package_Net_Weight = l.PackageNetWeight,
                            Reason_Entry = l.ReasonEntry,
                            Based_Weight = l.BasedWeight,
                            IsAccepted = l.IsAccepted,
                            RejectReason = l.RejectReason,
                            categoryName = Pick(cat?.NameAr, cat?.NameEn),
                            RecordedOrNot = cat?.IsRegister == true ? "مسجل" : "غير مسجل",
                            ItemCategoryGroup = cat == null ? null : (cat.ItemCategoriesGroupId == null ? "لا يوجد" : Pick(group?.NameAr, group?.NameEn)),
                            packageType = l.PackageTypeId != null && packageTypes.TryGetValue(l.PackageTypeId.Value, out var lpt) ? Pick(lpt.ArName, lpt.EnName) : null,
                            packageMaterialName = l.PackageMaterialId != null && packageMaterials.TryGetValue(l.PackageMaterialId.Value, out var lpm) ? Pick(lpm.ArName, lpm.EnName) : null,
                        };
                    })
                    .ToList();

                shipDto.Items_checkReq.Add(itemDto);
            }

            return shipDto;
        }).ToList();

        // distributed constrains list (one row per distinct initiator)
        var seen = new HashSet<long>();
        var constrainsList = new List<ItemsCheckReqDto>();
        foreach (var initiatorId in initiatorIds)
        {
            if (!seen.Add(initiatorId))
                continue;

            var initiator = initiators.GetValueOrDefault(initiatorId);
            if (initiator is null)
                continue;

            var initiatorCountry = initiator.CountryId != null ? countries.GetValueOrDefault(initiator.CountryId.Value) : null;
            var isn = initiator.ItemShortNameId != null ? shortNames.GetValueOrDefault(initiator.ItemShortNameId.Value) : null;
            var it = isn?.ItemId != null ? referencedItems.GetValueOrDefault(isn.ItemId.Value) : null;

            constrainsList.Add(new ItemsCheckReqDto
            {
                Im_Initiator_ID = initiatorId,
                InitiatorCountry = Pick(initiatorCountry?.ArName, initiatorCountry?.EnName),
                qualitiveGroupName = initiator.QualitativeGroupId != null && qualGroups.TryGetValue(initiator.QualitativeGroupId.Value, out var qg) ? Pick(qg.NameAr, qg.NameEn) : null,
                ItemShortNameAr = isn?.ShortNameAr,
                ItemShortNameEn = isn?.ShortNameEn,
                Status = isn?.ItemStatusId != null && statuses.TryGetValue(isn.ItemStatusId.Value, out var st2) ? Pick(st2.ArName, st2.EnName) : null,
                Purpose = isn?.ItemPurposeId != null && purposes.TryGetValue(isn.ItemPurposeId.Value, out var pu2) ? Pick(pu2.ArName, pu2.EnName) : null,
                subPartName = isn?.SubPartId != null && subParts.TryGetValue(isn.SubPartId.Value, out var sp2) ? Pick(sp2.NameAr, sp2.NameEn) : null,
                ItemName = Pick(it?.NameAr, it?.NameEn),
                Itemconstrains = constrainsByInitiator.GetValueOrDefault(initiatorId),
            });
        }

        dto.itemsWithConstrains = constrainsList;
    }

    private async Task<Dictionary<long, ConstrainsDto>> BuildConstrainsAsync(
        List<long> initiatorIds,
        CancellationToken cancellationToken)
    {
        var result = new Dictionary<long, ConstrainsDto>();
        if (initiatorIds.Count == 0)
            return result;

        var constrainTexts = await _db.ImConstrainInitiatorTexts.AsNoTracking()
            .Where(t => t.ImInitiatorId != null && initiatorIds.Contains(t.ImInitiatorId.Value) && t.IsActive)
            .Select(t => new
            {
                InitiatorId = t.ImInitiatorId!.Value,
                t.ConstrainText!.ConstrainTextAr,
                t.ConstrainText!.ConstrainTextEn,
                t.ConstrainText!.InSideCertificateAr,
                t.ConstrainText!.InSideCertificateEn,
            })
            .ToListAsync(cancellationToken);

        // allowed arrival ports, per item-short-name and per qualitative group
        var initiators = await _db.ImInitiators.AsNoTracking()
            .Where(i => initiatorIds.Contains(i.Id))
            .Select(i => new { i.Id, i.ItemShortNameId, i.QualitativeGroupId })
            .ToListAsync(cancellationToken);

        var shortNameIds = initiators.Where(i => i.ItemShortNameId != null).Select(i => i.ItemShortNameId!.Value).Distinct().ToList();
        var qualGroupIds = initiators.Where(i => i.QualitativeGroupId != null).Select(i => i.QualitativeGroupId!.Value).Distinct().ToList();

        var arrivalPorts = await _db.ImCountryConstrainArrivalPorts.AsNoTracking()
            .Where(p => p.IsActive
                && ((p.ItemShortNameId != null && shortNameIds.Contains(p.ItemShortNameId.Value))
                    || (p.IdQualitativeGroup != null && qualGroupIds.Contains(p.IdQualitativeGroup.Value))))
            .Select(p => new { p.ItemShortNameId, p.IdQualitativeGroup, p.PortNationalId, p.PortTypeId })
            .ToListAsync(cancellationToken);

        var portTypeIds = arrivalPorts.Select(p => p.PortTypeId).Distinct().ToList();
        var portTypeRows = await _db.PortTypes.AsNoTracking()
            .Where(p => portTypeIds.Contains(p.Id))
            .Select(p => new { p.Id, p.NameAr, p.NameEn })
            .ToListAsync(cancellationToken);
        var portTypes = portTypeRows.ToDictionary(p => p.Id, p => new NamePair(p.NameAr, p.NameEn));

        var portIds = arrivalPorts.Where(p => p.PortNationalId != null).Select(p => p.PortNationalId!.Value).Distinct().ToList();
        var portNameRows = await _db.PortNationals.AsNoTracking()
            .Where(p => portIds.Contains(p.Id))
            .Select(p => new { p.Id, p.NameAr, p.NameEn })
            .ToListAsync(cancellationToken);
        var portNames = portNameRows.ToDictionary(p => p.Id, p => new NamePair(p.NameAr, p.NameEn));

        foreach (var initiatorId in initiatorIds)
        {
            var initiator = initiators.FirstOrDefault(i => i.Id == initiatorId);
            var texts = constrainTexts.Where(t => t.InitiatorId == initiatorId).ToList();

            var ports = new List<ConstrainPortDto>();
            if (initiator != null && initiator.ItemShortNameId != null)
            {
                ports = arrivalPorts.Where(p => p.ItemShortNameId == initiator.ItemShortNameId).ToList()
                    .Select(p => BuildPort(p.PortNationalId, p.PortTypeId, portTypes, portNames))
                    .ToList();
            }

            // The legacy code evaluates the qualitative-group branch second and overwrites the
            // item-short-name result (it is not an else-if), applying the group filter the
            // corrected query uses.
            if (initiator != null && initiator.QualitativeGroupId != null)
            {
                ports = arrivalPorts.Where(p => p.IdQualitativeGroup == initiator.QualitativeGroupId).ToList()
                    .Select(p => BuildPort(p.PortNationalId, p.PortTypeId, portTypes, portNames))
                    .ToList();
            }

            result[initiatorId] = new ConstrainsDto
            {
                texts_Ar = texts.Select(t => t.ConstrainTextAr).ToList(),
                text_En = texts.Select(t => t.ConstrainTextEn).ToList(),
                InSide_Certificate_Ar = texts.Select(t => t.InSideCertificateAr).ToList(),
                InSide_Certificate_En = texts.Select(t => t.InSideCertificateEn).ToList(),
                itemConstrainPorts = ports,
            };
        }

        return result;
    }

    private static ConstrainPortDto BuildPort(
        int? portId,
        byte portTypeId,
        IReadOnlyDictionary<byte, NamePair> portTypes,
        IReadOnlyDictionary<int, NamePair> portNames)
    {
        portTypes.TryGetValue(portTypeId, out var portType);

        string? portName = null;
        if (portId != null && portNames.TryGetValue(portId.Value, out var port))
            portName = port.Resolve(IsArabic);

        return new ConstrainPortDto
        {
            portId = portId,
            portTypeId = portTypeId,
            portType = portType.Resolve(IsArabic),
            portName = portName,
        };
    }

    /// <summary>A resolved pair of Arabic/English display names.</summary>
    private readonly record struct NamePair(string? Ar, string? En)
    {
        public string? Resolve(bool isArabic) => isArabic ? Ar ?? En : En ?? Ar;
    }

    // ----- ports -----

    private async Task LoadPortsAsync(
        ImRequestDetailsDto dto,
        ImCheckRequestDatum data,
        CancellationToken cancellationToken)
    {
        var ports = await _db.ImCheckRequestPorts.AsNoTracking()
            .Where(p => p.ImCheckRequestDataId == data.Id)
            .ToListAsync(cancellationToken);

        var portTypeIds = ports.Select(p => p.PortTypeId).Distinct().ToList();
        var portTypes = await _db.PortTypes.AsNoTracking()
            .Where(p => portTypeIds.Contains(p.Id))
            .Select(p => new { p.Id, p.NameAr, p.NameEn })
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        var nationalIds = ports.Where(p => p.ReqPortTypeId == 10 && p.PortId != null).Select(p => p.PortId!.Value).Distinct().ToList();
        var nationalPorts = await _db.PortNationals.AsNoTracking()
            .Where(p => nationalIds.Contains(p.Id))
            .Select(p => new { p.Id, p.NameAr, p.NameEn, p.GovernId })
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        var governIds = nationalPorts.Values.Select(p => p.GovernId).Distinct().ToList();
        var governates = await _db.Governates.AsNoTracking()
            .Where(g => governIds.Contains(g.Id))
            .Select(g => new { g.Id, g.ArName, g.EnName })
            .ToDictionaryAsync(g => g.Id, cancellationToken);

        var internationalPortIds = ports.Where(p => (p.ReqPortTypeId == 9 || p.ReqPortTypeId == 11) && p.PortId != null)
            .Select(p => p.PortId!.Value).Distinct().ToList();
        var internationalPorts = await _db.PortInternationals.AsNoTracking()
            .Where(p => internationalPortIds.Contains(p.Id))
            .Select(p => new { p.Id, p.NameAr, p.NameEn, p.CountryId })
            .ToDictionaryAsync(p => p.Id, cancellationToken);

        var countryIds = internationalPorts.Values.Where(p => p.CountryId != null).Select(p => p.CountryId!.Value).Distinct().ToList();
        var countries = await _db.Countries.AsNoTracking()
            .Where(c => countryIds.Contains(c.Id))
            .Select(c => new { c.Id, c.ArName, c.EnName })
            .ToDictionaryAsync(c => c.Id, cancellationToken);

        dto.List_Port = ports.Select(p =>
        {
            var portType = portTypes.GetValueOrDefault(p.PortTypeId);
            var row = new ListPortDto
            {
                ReqPortType_ID = p.ReqPortTypeId,
                TransportPortType = Pick(portType?.NameAr, portType?.NameEn),
                ArrivePortType = Pick(portType?.NameAr, portType?.NameEn),
                TransitPortType = Pick(portType?.NameAr, portType?.NameEn),
            };

            if (p.ReqPortTypeId == 10 && p.PortId != null && nationalPorts.TryGetValue(p.PortId.Value, out var np))
            {
                row.ArrivePortName = Pick(np.NameAr, np.NameEn);
                var govern = governates.GetValueOrDefault(np.GovernId);
                row.govNameAR = govern?.ArName;
                row.govNameEN = govern?.EnName;
            }
            else if ((p.ReqPortTypeId == 9 || p.ReqPortTypeId == 11) && p.PortId != null && internationalPorts.TryGetValue(p.PortId.Value, out var ip))
            {
                var countryName = ip.CountryId != null && countries.TryGetValue(ip.CountryId.Value, out var c) ? Pick(c.ArName, c.EnName) : null;
                if (p.ReqPortTypeId == 9)
                {
                    row.TransportPortName = Pick(ip.NameAr, ip.NameEn);
                    row.ExportCountryName = countryName;
                }
                else
                {
                    row.TransitPort = Pick(ip.NameAr, ip.NameEn);
                    row.TransitCountry = countryName;
                }
            }

            return row;
        }).ToList();
    }

    // ----- attachments and linked permissions -----

    private async Task LoadAttachmentsAsync(
        ImRequestDetailsDto dto,
        ImCheckRequest request,
        CancellationToken cancellationToken)
    {
        dto.Attachments = await _db.AAttachmentData.AsNoTracking()
            .Where(v => v.RowId == request.Id && v.AAttachmentTableNameId == 8 && v.UserDeletionId == null)
            .Select(x => new AttachmentDto
            {
                Attachment_Number = x.AttachmentNumber,
                AttachmentPath = x.AttachmentPath,
                Attachment_TypeName = x.AttachmentTypeName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Attachment_Name = IsArabic ? x.AAttachmentTableType!.ArName : x.AAttachmentTableType!.EnName,
            })
            .ToListAsync(cancellationToken);

        dto.List_Permission = await _db.ImPermissionRequests.AsNoTracking()
            .Where(a => a.ImCheckRequestId == request.Id)
            .Select(z => new ListPermissionDto
            {
                ID = z.Id,
                ImPermission_Number = z.ImPermissionNumber,
            })
            .ToListAsync(cancellationToken);

        var permissionIds = dto.List_Permission.Select(p => p.ID).ToList();
        dto.AttachmentPermission = await _db.AAttachmentData.AsNoTracking()
            .Where(v => permissionIds.Contains(v.RowId) && v.AAttachmentTableNameId == 4 && v.UserDeletionId == null)
            .Select(x => new AttachmentPermissionDto
            {
                Attachment_Number = x.AttachmentNumber,
                AttachmentPath = x.AttachmentPath,
                Attachment_TypeName = x.AttachmentTypeName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Attachment_Name = IsArabic ? x.AAttachmentTableType!.ArName : x.AAttachmentTableType!.EnName,
            })
            .ToListAsync(cancellationToken);
    }

    // ----- customs -----

    private async Task LoadCustomsAsync(
        ImRequestDetailsDto dto,
        ImCheckRequest request,
        CancellationToken cancellationToken)
    {
        dto.CustomsMessages = await _db.ImCheckRequestCustomsMessages.AsNoTracking()
            .Where(i => i.ImCheckRequestId == request.Id)
            .Select(v => new CustomsMessageDto
            {
                Im_CheckRequest_ID = v.ImCheckRequestId,
                Customs_Certificate_Number = v.CustomsCertificateNumber,
                Shipment_Date = v.ShipmentDate != null ? v.ShipmentDate.Value.ToDateTime(TimeOnly.MinValue) : null,
                Certification_Date = v.CertificationDate != null ? v.CertificationDate.Value.ToDateTime(TimeOnly.MinValue) : null,
                Arrival_Date = v.ArrivalDate != null ? v.ArrivalDate.Value.ToDateTime(TimeOnly.MinValue) : null,
                Manifest_Number = v.ManifestNumber,
                Certificate_Number_Each_Product = v.CertificateNumberEachProduct,
                Shipping_Agency_ID = v.ShippingAgencyId,
                Shipping_Agency_Name = IsArabic ? v.ShippingAgency!.NameAr : v.ShippingAgency!.NameEn,
                OperationType_ID = v.ImOperationType,
            })
            .ToListAsync(cancellationToken);

        var operationTypeId = dto.CustomsMessages.Select(c => c.OperationType_ID).FirstOrDefault();
        if (operationTypeId != null)
        {
            dto.OperationType_Name = await _db.ImOpertaionTypes.AsNoTracking()
                .Where(a => a.Id == operationTypeId)
                .Select(s => IsArabic ? s.NameAr : s.NameEn)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
