using ISCC.Application.ImCommitteeFinalResult;
using ISCC.Application.ImCommitteeFinalResult.Dtos;
using ISCC.Infrastructure.Data;
using ISCC.Infrastructure.Data.Generated;
using ISCC.Infrastructure.Data.Privilage;
using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.ImCommitteeFinalResult;

/// <summary>
/// EF Core port of the legacy <c>ImCommittee_Final_ResultBLL</c> ("نتيجة لجان الوارد").
/// </summary>
public class ImCommitteeFinalResultService : IImCommitteeFinalResultService
{
    private const int OperationTypeImport = 74;

    private readonly PlantQuarantineDbContext _db;
    private readonly PrivilageDbContext _privilege;

    public ImCommitteeFinalResultService(PlantQuarantineDbContext db, PrivilageDbContext privilege)
    {
        _db = db;
        _privilege = privilege;
    }

    private static bool IsArabic =>
        System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName
            .StartsWith("ar", StringComparison.OrdinalIgnoreCase);

    private static string? Pick(string? arabic, string? english) =>
        IsArabic ? arabic ?? english : english ?? arabic;

    private long NextSequenceValue(string sequence) =>
        (long)_db.Database
            .SqlQueryRaw<decimal>($"SELECT NEXT VALUE FOR dbo.{sequence} AS value")
            .AsEnumerable()
            .First();

    // Fetches the employees' display names once per call, instead of one round trip per row.
    private async Task<Func<long?, string?>> EmployeeNameResolverAsync(
        IEnumerable<long?> employeeIds,
        CancellationToken cancellationToken)
    {
        var ids = employeeIds.Where(i => i.HasValue).Select(i => i!.Value).Distinct().ToList();
        if (ids.Count == 0)
            return _ => null;

        var rows = await _privilege.PrUsers
            .Where(u => ids.Contains(u.Id))
            .Select(u => new { u.Id, u.FullName, u.FullNameEn })
            .ToListAsync(cancellationToken);

        var map = rows.ToDictionary(x => (long)x.Id, x => IsArabic ? x.FullName : x.FullNameEn ?? x.FullName);
        return id => (id.HasValue && map.TryGetValue(id.Value, out var name)) ? name : null;
    }

    /// <inheritdoc />
    public async Task<ImCommittee_Final_ResultDTO?> GetAsync(
        long requestId,
        long itemShortNameId,
        long lotsItemShortNameId,
        long committeeTypeLstId,
        CancellationToken cancellationToken)
    {
        var header = await (
            from cc in _db.ImCheckRequests
            join crd in _db.ImCheckRequestData on cc.Id equals crd.ImCheckRequestId
            join icrp in _db.ImCheckRequestPorts on crd.Id equals icrp.ImCheckRequestDataId
            join pn in _db.PortNationals on icrp.PortId equals pn.Id
            where cc.Id == requestId && icrp.ReqPortTypeId == 10
            select new { cc, pn }).FirstOrDefaultAsync(cancellationToken);

        if (header is null)
            return null;

        var port = header.pn;
        var dto = new ImCommittee_Final_ResultDTO
        {
            Im_CheckRequest_ID = header.cc.Id,
            ImCheckRequest_Number = header.cc.CheckRequestNumber,
            OutLet_Name = header.cc.Outlet != null ? Pick(header.cc.Outlet.ArName, header.cc.Outlet.EnName) : null,
            OutLet_ID = header.cc.OutletId,
            StartDate = header.cc.UserCreationDate,
            ArrivePortType = Pick(port.PortType?.NameAr, port.PortType?.NameEn),
            ArrivePortName = $"{port.PortType?.NameAr}/{port.NameAr}/{port.Govern?.ArName}",
            govNameAR = Pick(port.Govern?.ArName, port.Govern?.EnName),
            CustomsMessages = new List<CustomsMessage>(),
            FinalResults = new List<FinalResult>(),
            CheckRequest_Visa = new List<CheckRequest_Visa>(),
            itemsWithConstrains = new List<Items_checkReq_New>(),
        };

        var lotIds = await _db.ImCheckRequestItemsLotCategories
            .Where(l => l.ImCheckRequestItems!.ImCheckRequsetShippingMethod!.ImCheckRequestId == requestId)
            .Select(l => l.Id)
            .ToListAsync(cancellationToken);

        var stoppedLots = await (
            from r in _db.ImCheckRequestItemsLotResults
            where lotIds.Contains(r.ImCheckRequestItemsLotCategoryId)
               && r.IsStatusNavigation != null
               && r.IsStatusNavigation.IsContinue == false
            select r.ImCheckRequestItemsLotCategoryId)
            .Distinct()
            .ToListAsync(cancellationToken);

        dto.Count_Lots = lotIds.Count - stoppedLots.Count;

        dto.CustomsMessages = await _db.ImCheckRequestCustomsMessages
            .Where(m => m.ImCheckRequestId == requestId)
            .Select(m => new CustomsMessage
            {
                Im_CheckRequest_ID = m.ImCheckRequestId,
                Customs_Certificate_Number = m.CustomsCertificateNumber,
                Shipment_Date = m.ShipmentDate != null ? m.ShipmentDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Certification_Date = m.CertificationDate != null ? m.CertificationDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Arrival_Date = m.ArrivalDate != null ? m.ArrivalDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Manifest_Number = m.ManifestNumber,
                Certificate_Number_Each_Product = m.CertificateNumberEachProduct,
                Shipping_Agency_ID = m.ShippingAgencyId,
                Shipping_Agency_Name = m.ShippingAgency != null ? Pick(m.ShippingAgency.NameAr, m.ShippingAgency.NameEn) : null,
            })
            .ToListAsync(cancellationToken);

        dto.FinalResults = await _db.ImCheckRequestFinalResults
            .Include(f => f.ImFinalResult)
            .Where(f => f.ImCheckRequestId == requestId)
            .Select(f => new FinalResult
            {
                Im_CheckRequest_FinalResult_ID = f.ImCheckRequestId,
                DateFinalResult = f.Date != null ? f.Date.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Final_Result_EmployeeId = f.UserCreationId,
                Final_Result_Status = f.ImFinalResult != null ? f.ImFinalResult.Status : null,
                Final_Result_Name = f.ImFinalResult != null ? Pick(f.ImFinalResult.ArName, f.ImFinalResult.EnName) : null,
            })
            .ToListAsync(cancellationToken);

        dto.CheckRequest_Visa = await _db.ImCheckRequestVisas
            .Include(v => v.ImVisa)
            .Where(v => v.ImCheckRequestId == requestId)
            .Select(v => new CheckRequest_Visa
            {
                Im_CheckRequest_Visa_ID = v.ImCheckRequestId,
                Date_Visa = v.Date != null ? v.Date.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Visa_Result_EmployeeId = v.UserCreationId,
                Visa_Result_Name = v.ImVisa != null ? Pick(v.ImVisa.DescriptionAr, v.ImVisa.DescriptionEn) : null,
            })
            .ToListAsync(cancellationToken);

        var permissionNumber = header.cc.CheckRequestNumber;

        var itemRows = await (
            from it in _db.ImCheckRequestItems
            join isn in _db.ItemShortNames on it.ItemShortNameId equals isn.Id
            where it.ItemPermissionNumber == permissionNumber
            select new
            {
                it.ImInitiatorId,
                it.ItemShortNameId,
                isn.ShortNameAr,
                isn.ShortNameEn,
                ItemId = isn.ItemId,
                ItemNameAr = isn.Item != null ? isn.Item.NameAr : null,
                ItemNameEn = isn.Item != null ? isn.Item.NameEn : null,
                QualityAr = isn.QualitativeGroup != null ? isn.QualitativeGroup.NameAr : null,
                QualityEn = isn.QualitativeGroup != null ? isn.QualitativeGroup.NameEn : null,
                CountryAr = it.ImInitiator != null && it.ImInitiator.Country != null ? it.ImInitiator.Country.ArName : null,
                CountryEn = it.ImInitiator != null && it.ImInitiator.Country != null ? it.ImInitiator.Country.EnName : null,
                it.GrossWeight,
                it.NetWeight,
            })
            .ToListAsync(cancellationToken);

        var groups = itemRows
            .GroupBy(x => new
            {
                x.ItemShortNameId,
                x.ShortNameAr,
                x.ShortNameEn,
                x.ItemId,
                x.ItemNameAr,
                x.ItemNameEn,
                x.QualityAr,
                x.QualityEn,
                x.CountryAr,
                x.CountryEn,
                x.ImInitiatorId,
            })
            .Select(g => new Items_checkReq_New
            {
                Im_Initiator_ID = g.Key.ImInitiatorId ?? 0,
                Item_ShortName_ID = g.Key.ItemShortNameId,
                ItemShortNameAr = g.Key.ShortNameAr,
                ItemShortNameEn = g.Key.ShortNameEn,
                Item_ID = g.Key.ItemId ?? 0,
                ItemName_Ar = g.Key.ItemNameAr,
                ItemName_En = g.Key.ItemNameEn,
                qualitiveGroupName = g.Key.QualityAr,
                qualitiveGroupNameEn = g.Key.QualityEn,
                InitiatorCountry = g.Key.CountryAr,
                InitiatorCountryEn = g.Key.CountryEn,
                GrossWeight = g.Sum(x => x.GrossWeight),
                Net_Weight = g.Sum(x => x.NetWeight),
                ItemCategories_lots = new List<categories_lots_New>(),
            })
            .ToList();

        if (itemShortNameId > 0)
            groups = groups.Where(g => g.Item_ShortName_ID == itemShortNameId).ToList();

        var categoryItems = await _db.ImCheckRequestItems
            .Where(it => it.ItemPermissionNumber == permissionNumber)
            .Select(it => new { it.Id, it.ItemShortNameId, it.ImInitiatorId })
            .ToListAsync(cancellationToken);

        foreach (var group in groups)
        {
            var shortName = await _db.ItemShortNames
                .Include(s => s.SubPart)
                .FirstOrDefaultAsync(s => s.Id == group.Item_ShortName_ID, cancellationToken);
            group.subPartName = shortName?.SubPart != null ? Pick(shortName.SubPart.NameAr, shortName.SubPart.NameEn) : null;

            var groupItemIds = categoryItems
                .Where(it => it.ItemShortNameId == group.Item_ShortName_ID && it.ImInitiatorId == group.Im_Initiator_ID)
                .Select(it => it.Id)
                .ToList();

            var lots = await _db.ImCheckRequestItemsLotCategories
                .Include(l => l.ItemCategory)
                .Include(l => l.ImCheckRequestItems)!.ThenInclude(i => i!.ImCheckRequsetShippingMethod)
                .Where(l => l.ImCheckRequestItemsId.HasValue && groupItemIds.Contains(l.ImCheckRequestItemsId.Value))
                .ToListAsync(cancellationToken);

            if (lotsItemShortNameId > 0)
                lots = lots.Where(l => l.Id == lotsItemShortNameId).ToList();

            foreach (var lot in lots)
            {
                var shipping = lot.ImCheckRequestItems?.ImCheckRequsetShippingMethod;

                var lotDto = new categories_lots_New
                {
                    ID_Lot = lot.Id,
                    Im_checkReqItems_ID = lot.ImCheckRequestItemsId,
                    Im_checkReqItemsCategory_ID = lot.ItemCategoryId,
                    categoryName = lot.ItemCategory != null ? Pick(lot.ItemCategory.NameAr, lot.ItemCategory.NameEn) : null,
                    categoryNameEn = lot.ItemCategory != null ? Pick(lot.ItemCategory.NameEn, lot.ItemCategory.NameAr) : null,
                    ItemCategory_ID = lot.ItemCategoryId,
                    Size = lot.Size,
                    Package_Count = lot.PackageCount,
                    Units_Number = lot.UnitsNumber,
                    Package_Weight = lot.PackageWeight,
                    Package_Based_Weight = lot.PackageBasedWeight,
                    Package_Net_Weight = lot.PackageNetWeight,
                    GrossWeight = lot.GrossWeight,
                    Net_Weight = lot.NetWeight,
                    Based_Weight = lot.BasedWeight,
                    Order_TextLot = lot.OrderText,
                    IsRegister = lot.ItemCategory?.IsRegister,
                    RecordedOrNot = lot.ItemCategoryId == null ? "#####" : (lot.ItemCategory.IsRegister == true ? "مسجل" : "غير مسجل"),
                    Lot_Number = lot.LotNumber,
                    Grower_Number = lot.GrowerNumber,
                    Waybill = lot.Waybill,
                    Number_Wooden_Package = lot.NumberWoodenPackage,
                    Reason_Entry = lot.ReasonEntry,
                    RejectReason = lot.RejectReason,
                    IsAccepted = lot.IsAccepted,
                    ID_IM_Item = lot.ImCheckRequestItemsId ?? 0,
                    Order_Text = lot.OrderText,
                };

                lotDto.packageType = lot.PackageTypeId.HasValue
                    ? await _db.PackageTypes
                        .Where(p => p.Id == lot.PackageTypeId.Value)
                        .Select(p => Pick(p.ArName, p.EnName))
                        .FirstOrDefaultAsync(cancellationToken)
                    : null;
                lotDto.packageTypeID = lot.PackageTypeId;

                lotDto.packageMaterialName = lot.PackageMaterialId.HasValue
                    ? await _db.PackageMaterials
                        .Where(p => p.Id == lot.PackageMaterialId.Value)
                        .Select(p => Pick(p.ArName, p.EnName))
                        .FirstOrDefaultAsync(cancellationToken)
                    : null;
                lotDto.packageMaterialID = lot.PackageMaterialId;
                lotDto.packageMaterial = lotDto.packageMaterialName;

                lotDto.ContainerNumber = shipping?.ContainerNumber;
                lotDto.Container_Number = shipping?.ContainerNumber;
                lotDto.containerName = shipping?.ContainersId != null
                    ? await _db.ASystemCodes
                        .Where(c => c.Id == shipping.ContainersId)
                        .Select(c => c.ValueName)
                        .FirstOrDefaultAsync(cancellationToken)
                    : null;
                lotDto.containerType = shipping?.ContainersTypeId != null
                    ? await _db.ASystemCodes
                        .Where(c => c.Id == shipping.ContainersTypeId && c.SystemCodeTypeId == 29)
                        .Select(c => c.ValueName)
                        .FirstOrDefaultAsync(cancellationToken)
                    : null;
                lotDto.ShipholdNumber = shipping?.ShipholdNumber;
                lotDto.ShipmentPolicy_Number = shipping?.ShipholdNumber;
                lotDto.NavigationalNumber = shipping?.NavigationalNumber;
                lotDto.NavigationalFluid_Number = shipping?.NavigationalNumber;
                lotDto.Total_Weight = shipping?.TotalWeight;
                lotDto.ItemCategoryGroup = lot.ItemCategoryId == null
                    ? "#####"
                    : (lot.ItemCategory?.ItemCategoriesGroupId == null
                        ? "لا يوجد"
                        : await _db.ItemCategoriesGroups
                            .Where(g => g.Id == lot.ItemCategory!.ItemCategoriesGroupId)
                            .Select(g => Pick(g.NameAr, g.NameEn))
                            .FirstOrDefaultAsync(cancellationToken));

                lotDto.Lot_Status_Result = await _db.ImCheckRequestItemsLotResults
                    .Include(r => r.IsStatusNavigation)
                    .Where(r => r.ImCheckRequestItemsLotCategoryId == lot.Id)
                    .Select(r => new Lot_Status_Result
                    {
                        Lot_Status_Result_ID = r.Id,
                        IS_Status_Lot_Result = r.IsStatus,
                        IS_Status_Name = r.IsStatusNavigation != null ? Pick(r.IsStatusNavigation.NameAr, r.IsStatusNavigation.NameEn) : null,
                        Note_Lot_Result = r.Nots,
                        IS_Status_Committee = r.IsStatusCommittee,
                        Is_Continue = r.IsStatusNavigation != null ? r.IsStatusNavigation.IsContinue : null,
                        User_Creation_Date = r.UserCreationDate,
                        User_Creation_Id = r.UserCreationId,
                    })
                    .ToListAsync(cancellationToken);

                lotDto.CommitteeResultType_ID = await _db.ImCommitteeResults
                    .Where(cr => cr.LotDataId == lot.Id)
                    .GroupBy(cr => cr.CommitteeResultTypeId)
                    .OrderByDescending(g => g.Max(x => x.Id))
                    .Select(g => g.Key)
                    .FirstOrDefaultAsync(cancellationToken);

                if (committeeTypeLstId == 0 || committeeTypeLstId == 11)
                    lotDto.Lot_Committee_Result = await BuildInspectionResultsAsync(lot.Id, cancellationToken);

                if (committeeTypeLstId == 0 || committeeTypeLstId == 13)
                    lotDto.List_Lot_Committee_Sample = await BuildSampleResultsAsync(lot.Id, cancellationToken);

                if (committeeTypeLstId == 0 || committeeTypeLstId == 14)
                    lotDto.List_Treatment = await BuildTreatmentResultsAsync(lot.Id, cancellationToken);

                lotDto.AttachmentData_Im_CommitteeResult_Infection = new List<List_AttachmentData_Im_CommitteeResult_Infection>();

                group.ItemCategories_lots!.Add(lotDto);
            }

            dto.itemsWithConstrains.Add(group);
        }

        var resolver = await EmployeeNameResolverAsync(CollectEmployeeIds(dto), cancellationToken);
        FillEmployeeNames(dto, resolver);
        return dto;
    }

    private async Task<List<Committee_Result_Lot>> BuildInspectionResultsAsync(long lotId, CancellationToken cancellationToken)
    {
        var rows = await (
            from cr in _db.ImCommitteeResults
            join rc in _db.ImRequestCommittees on cr.CommitteeId equals rc.Id
            where cr.LotDataId == lotId
            select new { cr, rc })
            .ToListAsync(cancellationToken);

        var result = new List<Committee_Result_Lot>();

        foreach (var row in rows)
        {
            var admin = await _db.CommitteeEmployees
                .Where(a => a.CommitteeId == row.rc.Id
                            && a.Isadmin
                            && a.OperationType == OperationTypeImport
                            && a.UserDeletionId == null
                            && a.UserDeletionDate == null)
                .FirstOrDefaultAsync(cancellationToken);

            var dto = new Committee_Result_Lot
            {
                Committee_Result_Lot_ID = row.cr.Id,
                Committee_ID = admin?.CommitteeId ?? row.rc.Id,
                EmployeeId = admin?.EmployeeId,
                ResultTypes_Name = row.cr.CommitteeResultTypeId == null
                    ? null
                    : await _db.CommitteeResultTypes
                        .Where(t => t.Id == row.cr.CommitteeResultTypeId!.Value)
                        .Select(t => Pick(t.NameAr, t.NameEn))
                        .FirstOrDefaultAsync(cancellationToken),
                Date = row.cr.Date,
                Notes = row.cr.Notes,
                IsAdminFinalResult = row.cr.IsAdminResult,
                Weight = row.cr.Weight ?? 0,
                QuantitySize = row.cr.QuantitySize ?? 0,
                IsFinishedAll = row.rc.IsFinishedAll,
                IsApproved = row.rc.IsApproved,
                Status = row.rc.Status,
                Delegation_Date = row.rc.DelegationDate != null ? row.rc.DelegationDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                StartTime = row.rc.StartTime != default ? row.rc.StartTime.ToTimeSpan() : (TimeSpan?)null,
                EndTime = row.rc.EndTime != default ? row.rc.EndTime.ToTimeSpan() : (TimeSpan?)null,
                ISAdmin = admin?.Isadmin,
                Is_Result_Finch = row.cr.CommitteeResultTypeId != null,
                IS_Total = row.cr.IsTotal,
                IS_TotalAndroid = row.cr.IsTotalAndroid,
            };

            // Non-admin employees, joined left to the confirmation row for this result row.
            var confirmRows = await (
                from cr2 in _db.ImCommitteeResults
                join ce in _db.CommitteeEmployees on cr2.CommitteeId equals ce.CommitteeId
                join confirm in _db.ImCommitteeResultConfirms
                    on new { crId = cr2.Id, empId = ce.EmployeeId }
                    equals new { crId = confirm.ImCommitteeResultId, empId = confirm.EmployeeId }
                    into confirmGroup
                from confirm in confirmGroup.DefaultIfEmpty()
                where cr2.CommitteeId == row.rc.Id
                   && cr2.LotDataId == lotId
                   && !ce.Isadmin
                   && ce.OperationType == OperationTypeImport
                select new { ce, confirm })
                .ToListAsync(cancellationToken);

            dto.List_Committee_Result_Conferm = confirmRows.Select(x => new Committee_Result_Lot_Conferm
            {
                EmployeeId = x.ce.EmployeeId,
                Notes = x.confirm?.Notes,
                Date = x.confirm?.Date,
                IsAccepted = x.confirm?.IsAccepted,
                User_Deletion_Date = x.ce.UserDeletionDate,
                User_Deletion_Id = x.ce.UserDeletionId,
            }).ToList();

            var infections = await _db.ImCommitteeResultInfections
                .Include(i => i.Item)!.ThenInclude(i => i!.Family)
                .Include(i => i.Item)!.ThenInclude(i => i!.Group)
                .Where(i => i.ImCommitteeResultId == row.cr.Id)
                .ToListAsync(cancellationToken);

            dto.List_Im_CommitteeResult_Infection = infections.Select(x => new List_Im_CommitteeResult_Infection
            {
                ID = x.Id,
                Item_ID = x.ItemId,
                Im_CommitteeResult_ID = x.ImCommitteeResultId,
                Item_Name = x.Item != null ? Pick(x.Item.NameAr, x.Item.NameEn) : null,
                Scientific_Name = x.Item?.ScientificName,
                Description = x.Item != null ? Pick(x.Item.DescreptionAr, x.Item.DescreptionEn) : null,
                Picture = x.Item?.Picture,
                FamliyName = x.Item?.Family != null ? Pick(x.Item.Family.NameAr, x.Item.Family.NameEn) : null,
                Group_Name = x.Item?.Group != null ? Pick(x.Item.Group.NameAr, x.Item.Group.NameEn) : null,
                Is_Forbidden_Reason = x.Item?.ForbiddenReason ?? "---",
                ItemName = x.Item != null ? Pick(x.Item.NameAr, x.Item.NameEn) : null,
                Is_Forbidden = x.Item != null && x.Item.IsForbidden ? "غير مسموح" : "مسموح",
                Is_Plant_Egypt = x.Item?.IsPlantInEgypt == true ? "نعم" : "لا",
                Is_Known_Item = x.Item?.IsKnownItem?.ToString(),
            }).ToList();

            result.Add(dto);
        }

        return result;
    }

    private async Task<List<Committee_Sample_Lot>> BuildSampleResultsAsync(long lotId, CancellationToken cancellationToken)
    {
        var samples = await _db.ImCheckRequestSampleData
            .Include(s => s.AnalysisLabType)!.ThenInclude(a => a!.AnalysisLab)
            .Include(s => s.AnalysisLabType)!.ThenInclude(a => a!.AnalysisType)
            .Include(s => s.ImRequestCommittee)
            .Where(s => s.LotDataId == lotId)
            .ToListAsync(cancellationToken);

        var result = new List<Committee_Sample_Lot>();

        foreach (var sample in samples)
        {
            var admin = await _db.CommitteeEmployees
                .Where(a => a.CommitteeId == sample.ImRequestCommitteeId
                            && a.Isadmin
                            && a.OperationType == OperationTypeImport
                            && a.UserDeletionId == null
                            && a.UserDeletionDate == null)
                .FirstOrDefaultAsync(cancellationToken);

            var confirms = await (
                from s in _db.ImCheckRequestSampleData
                join ce in _db.CommitteeEmployees on s.ImRequestCommitteeId equals ce.CommitteeId
                join confirm in _db.ImCheckRequestSampleDataConfirms
                    on new { sId = s.Id, EmpId = ce.EmployeeId } equals new { sId = confirm.ImCheckRequestSampleDataId, EmpId = (long)confirm.EmployeeId }
                    into confirmGroup
                from confirm in confirmGroup.DefaultIfEmpty()
                where s.ImRequestCommitteeId == sample.ImRequestCommitteeId
                   && s.LotDataId == lotId
                   && !ce.Isadmin
                   && ce.OperationType == OperationTypeImport
                select new { ce, confirm })
                .ToListAsync(cancellationToken);

            var dto = new Committee_Sample_Lot
            {
                ID = sample.Id,
                Committee_ID = sample.ImRequestCommitteeId,
                Im_RequestCommittee_ID = sample.ImRequestCommitteeId,
                Im_Request_Item_Id = sample.ImRequestItemId,
                LotData_ID = sample.LotDataId,
                EmployeeId = admin?.EmployeeId,
                ISAdmin = admin?.Isadmin,
                AnalysisLabType_ID = sample.AnalysisLabTypeId,
                Analysis_Name = sample.AnalysisLabType?.AnalysisType != null
                    ? Pick(sample.AnalysisLabType.AnalysisType.NameAr, sample.AnalysisLabType.AnalysisType.NameEn)
                    : null,
                Lab_Name = sample.AnalysisLabType?.AnalysisLab != null
                    ? Pick(sample.AnalysisLabType.AnalysisLab.NameAr, sample.AnalysisLabType.AnalysisLab.NameEn)
                    : null,
                WithdrawDate = sample.WithdrawDate != null ? sample.WithdrawDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Sample_BarCode = sample.SampleBarCode,
                SampleSize = sample.SampleSize,
                SampleRatio = sample.SampleRatio,
                IsAccepted = sample.IsAccepted,
                Notes = Pick(sample.NotesAr, sample.NotesEn),
                RejectReason_Ar = sample.RejectReasonAr,
                RejectReason_En = sample.RejectReasonEn,
                Admin_Confirmation = sample.AdminConfirmation,
                Admin_User = sample.AdminUser,
                Admin_Date = sample.AdminDate,
                IsPrint = sample.IsPrint,
                Is_Sample_Finch = false,
                IS_Total = sample.IsTotal,
                IS_TotalAndroid = sample.IsTotalAndroid,
                Syl_ALkhatima_Number = sample.SylAlkhatimaNumber,
                Delegation_Date = sample.ImRequestCommittee?.DelegationDate != null
                    ? sample.ImRequestCommittee.DelegationDate.Value.ToDateTime(TimeOnly.MinValue)
                    : (DateTime?)null,
                IsFinishedAll = sample.ImRequestCommittee?.IsFinishedAll,
                IsApproved = sample.ImRequestCommittee?.IsApproved,
                Status = sample.ImRequestCommittee?.Status,
            };

            dto.Imge_SampleLabResult = await _db.AAttachmentData
                .Where(a => a.RowId == sample.Id && a.AAttachmentTableNameId == 12)
                .OrderByDescending(a => a.Id)
                .Select(a => a.AttachmentPath)
                .FirstOrDefaultAsync(cancellationToken);

            dto.List_Committee_Sample_Conferm = confirms.Select(x => new Committee_Sample_Conferm
            {
                EmployeeId = x.ce.EmployeeId,
                Notes = x.confirm?.Notes,
                Date = x.confirm?.Date,
                IsAccepted = x.confirm?.IsAccepted,
                User_Deletion_Date = x.ce.UserDeletionDate,
                User_Deletion_Id = x.ce.UserDeletionId,
            }).ToList();

            result.Add(dto);
        }

        return result;
    }

    private async Task<List<List_Treatment_Data>> BuildTreatmentResultsAsync(long lotId, CancellationToken cancellationToken)
    {
        var treatments = await _db.ImRequestTreatmentData
            .Include(t => t.TreatmentMat)!.ThenInclude(m => m!.Item)
            .Include(t => t.ImRequestCommittee)
            .Where(t => t.ImRequestLotDataId == lotId)
            .ToListAsync(cancellationToken);

        var result = new List<List_Treatment_Data>();

        foreach (var treatment in treatments)
        {
            var admin = await _db.CommitteeEmployees
                .Where(a => a.CommitteeId == treatment.ImRequestCommitteeId
                            && a.Isadmin
                            && a.OperationType == OperationTypeImport
                            && a.UserDeletionId == null
                            && a.UserDeletionDate == null)
                .FirstOrDefaultAsync(cancellationToken);

            var treatmentType = treatment.TreatmentTypeId.HasValue
                ? await _db.TreatmentTypes.FirstOrDefaultAsync(t => t.Id == treatment.TreatmentTypeId.Value, cancellationToken)
                : null;

            var treatmentMethod = await _db.TreatmentMethods
                .Where(m => m.Id == treatment.TreatmentMethodId)
                .FirstOrDefaultAsync(cancellationToken);

            var companyName = treatment.CompanyId.HasValue
                ? await _db.CompanyNationals
                    .Where(c => c.Id == treatment.CompanyId.Value)
                    .Select(c => Pick(c.NameAr, c.NameEn))
                    .FirstOrDefaultAsync(cancellationToken)
                : null;

            var dto = new List_Treatment_Data
            {
                ID = treatment.Id,
                Committee_ID = treatment.ImRequestCommitteeId,
                Im_RequestCommittee_ID = treatment.ImRequestCommitteeId,
                Im_Request_Item_Id = treatment.ImRequestItemId,
                Im_Request_LotData_ID = treatment.ImRequestLotDataId,
                EmployeeId = admin?.EmployeeId,
                TreatmentType_ID = treatment.TreatmentTypeId,
                TreatmentType_Name = treatmentType != null ? Pick(treatmentType.ArName, treatmentType.EnName) : null,
                Company_ID = treatment.CompanyId,
                Company_Name = companyName,
                Station_ID = treatment.StationId,
                Station_Place = treatment.StationPlace,
                TreatmentMethod_ID = treatment.TreatmentMethodId,
                TreatmentMethod_Name = treatmentMethod != null ? Pick(treatmentMethod.ArName, treatmentMethod.EnName) : null,
                Exposure_Day = treatment.ExposureDay,
                Exposure_Hour = treatment.ExposureHour,
                Exposure_Minute = treatment.ExposureMinute,
                ThermalSealNumber = treatment.ThermalSealNumber,
                TreatmentMat_Name = treatment.TreatmentMat?.Item != null
                    ? Pick(treatment.TreatmentMat.Item.NameAr, treatment.TreatmentMat.Item.NameEn)
                    : null,
                Note = treatment.Note,
                Size = treatment.Size,
                TreatmentMat_Amount = treatment.TreatmentMatAmount,
                Temperature = treatment.Temperature,
                TheDose = treatment.TheDose,
                User_Creation_Id = treatment.UserCreationId,
                User_Creation_Date = treatment.UserCreationDate,
                Is_Cancel = treatment.ImRequestCommittee?.IsCancel,
                IsFinishedAll = treatment.ImRequestCommittee?.IsFinishedAll,
                IsApproved = treatment.ImRequestCommittee?.IsApproved,
                Delegation_Date = treatment.ImRequestCommittee?.DelegationDate != null
                    ? treatment.ImRequestCommittee.DelegationDate.Value.ToDateTime(TimeOnly.MinValue)
                    : (DateTime?)null,
                Procedures = treatment.Procedures,
            };

            var confirms = await (
                from t in _db.ImRequestTreatmentData
                join ce in _db.CommitteeEmployees on t.ImRequestCommitteeId equals ce.CommitteeId
                join confirm in _db.ImRequestTreatmentDataConfirms
                    on new { tId = t.Id, empId = ce.EmployeeId } equals new { tId = confirm.ImRequestTreatmentDataId, empId = confirm.EmployeeId }
                    into confirmGroup
                from confirm in confirmGroup.DefaultIfEmpty()
                where t.ImRequestCommitteeId == treatment.ImRequestCommitteeId
                   && t.ImRequestLotDataId == lotId
                   && !ce.Isadmin
                   && ce.OperationType == OperationTypeImport
                select new { ce, confirm })
                .ToListAsync(cancellationToken);

            dto.List_Treatment_Confirm = confirms.Select(x => new List_Treatment_Data_Confirm
            {
                EmployeeId = x.ce.EmployeeId,
                Notes = x.confirm?.Notes,
                Date = x.confirm?.Date,
                IsAccepted = x.confirm?.IsAccepted,
                User_Deletion_Date = x.ce.UserDeletionDate,
                User_Deletion_Id = x.ce.UserDeletionId,
            }).ToList();

            result.Add(dto);
        }

        return result;
    }

    private static IEnumerable<long?> CollectEmployeeIds(ImCommittee_Final_ResultDTO dto)
    {
        foreach (var f in dto.FinalResults)
            yield return f.Final_Result_EmployeeId.HasValue ? f.Final_Result_EmployeeId.Value : null;
        foreach (var v in dto.CheckRequest_Visa)
            yield return v.Visa_Result_EmployeeId.HasValue ? v.Visa_Result_EmployeeId.Value : null;
        foreach (var item in dto.itemsWithConstrains)
        foreach (var lot in item.ItemCategories_lots ?? Enumerable.Empty<categories_lots_New>())
        {
            if (lot.Lot_Status_Result != null)
                foreach (var status in lot.Lot_Status_Result)
                    yield return status.User_Creation_Id.HasValue ? status.User_Creation_Id.Value : null;
            if (lot.Lot_Committee_Result != null)
                foreach (var committee in lot.Lot_Committee_Result)
                {
                    yield return committee.EmployeeId;
                    if (committee.List_Committee_Result_Conferm != null)
                        foreach (var confirm in committee.List_Committee_Result_Conferm)
                            yield return confirm.EmployeeId;
                }
            if (lot.List_Lot_Committee_Sample != null)
                foreach (var sample in lot.List_Lot_Committee_Sample)
                {
                    yield return sample.EmployeeId;
                    if (sample.List_Committee_Sample_Conferm != null)
                        foreach (var confirm in sample.List_Committee_Sample_Conferm)
                            yield return confirm.EmployeeId;
                }
            if (lot.List_Treatment != null)
                foreach (var treatment in lot.List_Treatment)
                {
                    yield return treatment.EmployeeId;
                    if (treatment.List_Treatment_Confirm != null)
                        foreach (var confirm in treatment.List_Treatment_Confirm)
                            yield return confirm.EmployeeId;
                }
        }
    }

    private static void FillEmployeeNames(ImCommittee_Final_ResultDTO dto, Func<long?, string?> resolver)
    {
        foreach (var f in dto.FinalResults)
            f.Final_Result_Employee_Name = resolver(f.Final_Result_EmployeeId.HasValue ? f.Final_Result_EmployeeId.Value : null);
        foreach (var v in dto.CheckRequest_Visa)
            v.Visa_Result_Employee_Name = resolver(v.Visa_Result_EmployeeId.HasValue ? v.Visa_Result_EmployeeId.Value : null);
        foreach (var item in dto.itemsWithConstrains)
        foreach (var lot in item.ItemCategories_lots ?? Enumerable.Empty<categories_lots_New>())
        {
            if (lot.Lot_Status_Result != null)
                foreach (var status in lot.Lot_Status_Result)
                    status.User_Name = resolver(status.User_Creation_Id.HasValue ? status.User_Creation_Id.Value : null);
            if (lot.Lot_Committee_Result != null)
                foreach (var committee in lot.Lot_Committee_Result)
                {
                    committee.Employee_Name = resolver(committee.EmployeeId);
                    if (committee.List_Committee_Result_Conferm != null)
                        foreach (var confirm in committee.List_Committee_Result_Conferm)
                        {
                            confirm.Employee_Name = resolver(confirm.EmployeeId);
                            confirm.Employee_Name_Conferm = confirm.Employee_Name;
                        }
                }
            if (lot.List_Lot_Committee_Sample != null)
                foreach (var sample in lot.List_Lot_Committee_Sample)
                {
                    sample.Employee_Name = resolver(sample.EmployeeId);
                    if (sample.List_Committee_Sample_Conferm != null)
                        foreach (var confirm in sample.List_Committee_Sample_Conferm)
                        {
                            confirm.Employee_Name = resolver(confirm.EmployeeId);
                            confirm.Employee_Name_Conferm = confirm.Employee_Name;
                        }
                }
            if (lot.List_Treatment != null)
                foreach (var treatment in lot.List_Treatment)
                {
                    treatment.Employee_Name = resolver(treatment.EmployeeId);
                    if (treatment.List_Treatment_Confirm != null)
                        foreach (var confirm in treatment.List_Treatment_Confirm)
                        {
                            confirm.Employee_Name = resolver(confirm.EmployeeId);
                            confirm.Employee_Name_Conferm = confirm.Employee_Name;
                        }
                }
        }
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<CustomOptionLongId>> GetItemShortNamesAsync(long requestId, CancellationToken cancellationToken)
    {
        var ccNumber = await _db.ImCheckRequests
            .Where(r => r.Id == requestId)
            .Select(r => r.CheckRequestNumber)
            .FirstOrDefaultAsync(cancellationToken);

        if (ccNumber == null)
            return new List<CustomOptionLongId>();

        return await (
            from it in _db.ImCheckRequestItems
            join isn in _db.ItemShortNames on it.ItemShortNameId equals isn.Id
            where it.ItemPermissionNumber == ccNumber && it.ItemShortNameId != null
            select new { it.ItemShortNameId, Ar = isn.ShortNameAr, En = isn.ShortNameEn })
            .Distinct()
            .OrderBy(x => x.Ar)
            .Select(x => new CustomOptionLongId
            {
                Value = x.ItemShortNameId!.Value,
                DisplayText = Pick(x.Ar, x.En) ?? string.Empty,
            })
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<CustomOptionLongId>> GetLotsAsync(long requestId, long itemShortNameId, CancellationToken cancellationToken)
    {
        return await _db.ImCheckRequestItems
            .Where(it => it.ImCheckRequsetShippingMethod!.ImCheckRequestId == requestId
                         && it.ItemShortNameId == itemShortNameId)
            .SelectMany(it => it.ImCheckRequestItemsLotCategories)
            .Select(lot => new CustomOptionLongId
            {
                Value = lot.Id,
                DisplayText = lot.LotNumber ?? string.Empty,
            })
            .Distinct()
            .OrderBy(x => x.DisplayText)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task SaveLotResultAsync(long requestId, Im_CheckRequest_Items_Lot_ResultDTO lotResult, CancellationToken cancellationToken)
    {
        await using var tx = await _db.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var previous = await _db.ImCheckRequestItemsLotResults
                .Where(r => r.ImCheckRequestItemsLotCategoryId == lotResult.Im_CheckRequest_Items_Lot_Category_ID)
                .ToListAsync(cancellationToken);

            foreach (var row in previous)
            {
                row.IsStatusCommittee = false;
                _db.ImCheckRequestItemsLotResults.Update(row);
            }

            var id = NextSequenceValue("Im_CheckRequest_Items_Lot_Result_SEQ");
            _db.ImCheckRequestItemsLotResults.Add(new ImCheckRequestItemsLotResult
            {
                Id = id,
                ImCheckRequestItemsLotCategoryId = lotResult.Im_CheckRequest_Items_Lot_Category_ID,
                IsStatus = lotResult.IS_Status,
                IsStatusCommittee = false,
                Nots = lotResult.Nots,
                UserCreationId = lotResult.User_Creation_Id,
                UserCreationDate = lotResult.User_Creation_Date,
            });

            AddLog(ID_TableAction: 47, ID_TableActionValue: lotResult.Im_CheckRequest_Items_Lot_Category_ID, requestId: requestId,
                notes: " حفظ موقف اللوط من خلال الحجر الزراعي", userId: lotResult.User_Creation_Id);

            await _db.SaveChangesAsync(cancellationToken);
            await tx.CommitAsync(cancellationToken);
        }
        catch
        {
            await tx.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private void AddLog(short ID_TableAction, long ID_TableActionValue, long requestId, string notes, short? userId)
    {
        _db.TableActionLogCheckRequests.Add(new TableActionLogCheckRequest
        {
            Id = NextSequenceValue("Table_Action_Log_CheckRequest_SEQ"),
            IdTableAction = ID_TableAction,
            IdTableActionValue = ID_TableActionValue,
            ImCheckRequestId = requestId,
            Nots = notes,
            UserCreationId = userId,
            UserCreationDate = DateTime.Now,
            UserTypeId = 127,
            TypeLogId = 135,
        });
    }

    /// <inheritdoc />
    public async Task SaveFinalResultAsync(long requestId, Im_CheckRequest_Final_ResultDTO finalResult, CancellationToken cancellationToken)
    {
        await using var tx = await _db.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = NextSequenceValue("Im_CheckRequest_Final_Result_SEQ");
            _db.ImCheckRequestFinalResults.Add(new ImCheckRequestFinalResult
            {
                Id = id,
                ImCheckRequestId = finalResult.Im_CheckRequest_ID ?? requestId,
                ImFinalResultId = finalResult.Im_Final_Result_ID,
                Date = finalResult.Date != null ? DateOnly.FromDateTime(finalResult.Date.Value) : null,
                UserCreationId = finalResult.User_Creation_Id,
                UserCreationDate = finalResult.User_Creation_Date,
            });

            AddLog(ID_TableAction: 15, ID_TableActionValue: finalResult.Im_Final_Result_ID ?? 0, requestId: requestId,
                notes: " حفظ الموقف النهائي من خلال الحجر الزراعي", userId: finalResult.User_Creation_Id);

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
    public async Task SaveVisaAsync(long requestId, Im_CheckRequest_VisaDTO visa, CancellationToken cancellationToken)
    {
        await using var tx = await _db.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var id = NextSequenceValue("Im_CheckRequest_Visa_SEQ");
            _db.ImCheckRequestVisas.Add(new ImCheckRequestVisa
            {
                Id = id,
                ImCheckRequestId = visa.Im_CheckRequest_ID ?? requestId,
                ImVisaId = visa.Im_Visa_ID,
                Date = visa.Date != null ? DateOnly.FromDateTime(visa.Date.Value) : null,
                UserCreationId = visa.User_Creation_Id,
                UserCreationDate = visa.User_Creation_Date,
            });

            AddLog(ID_TableAction: 17, ID_TableActionValue: visa.Im_Visa_ID ?? 0, requestId: requestId,
                notes: "تم حفظ التأشيرة ", userId: visa.User_Creation_Id);

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
    public async Task<Im_Visa_DataDTO?> GetVisaDataAsync(int visaId, CancellationToken cancellationToken) =>
        await _db.ImVisas
            .Where(v => v.Id == visaId)
            .Select(v => new Im_Visa_DataDTO
            {
                ID = v.Id,
                Ar_Name = v.ArName,
                En_Name = v.EnName,
                Description_Ar = v.DescriptionAr,
                Description_En = v.DescriptionEn,
            })
            .FirstOrDefaultAsync(cancellationToken);

    /// <inheritdoc />
    public async Task<IReadOnlyList<CustomOption>> GetLotStatusesAsync(CancellationToken cancellationToken)
    {
        var rows = await _db.ImCheckRequestLotResultStatuses
            .OrderBy(s => s.Id)
            .Select(s => new CustomOption
            {
                Value = s.Id,
                Value2 = s.IsContinue,
                DisplayText = $"{Pick(s.NameAr, s.NameEn)} / {(s.IsContinue == true ? "يوجد اجراء" : "لا يوجد اجراء اخر")}",
            })
            .ToListAsync(cancellationToken);

        var result = new List<CustomOption> { new() { DisplayText = "----------", Value = 0 } };
        result.AddRange(rows);
        return result;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteCommitteeEmployeeAsync(long requestId, long committeeId, long employeeId, short userId, CancellationToken cancellationToken)
    {
        var row = await _db.CommitteeEmployees
            .Where(ce => ce.CommitteeId == committeeId
                         && ce.EmployeeId == employeeId
                         && ce.OperationType == OperationTypeImport
                         && ce.Isadmin == false
                         && ce.UserDeletionId == null
                         && ce.UserDeletionDate == null)
            .FirstOrDefaultAsync(cancellationToken);

        if (row is null)
            return false;

        row.UserDeletionDate = DateTime.Now;
        row.UserDeletionId = userId;
        _db.CommitteeEmployees.Update(row);

        AddLog(ID_TableAction: 26, ID_TableActionValue: committeeId, requestId: requestId,
            notes: "حذف مساعد اللجنة من خلال موظف الحجر", userId: userId);

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <inheritdoc />
    public async Task<bool> SetLotResultStatusAsync(long statusId, bool status, CancellationToken cancellationToken)
    {
        var row = await _db.ImCheckRequestItemsLotResults
            .FirstOrDefaultAsync(r => r.Id == statusId, cancellationToken);

        if (row is null)
            return false;

        row.IsStatusCommittee = status;
        _db.ImCheckRequestItemsLotResults.Update(row);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
