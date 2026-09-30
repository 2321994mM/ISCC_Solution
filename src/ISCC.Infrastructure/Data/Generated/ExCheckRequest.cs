using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class ExCheckRequest
{
    public long Id { get; set; }

    public long? OutletId { get; set; }

    public string CheckRequestNumber { get; set; } = null!;

    public string? ExportCompany { get; set; }

    public string? ExportCompanyAddress { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsAccepted { get; set; }

    /// <summary>
    /// from A_SystemCode =3
    /// </summary>
    public int? UserTypeId { get; set; }

    public long? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public long? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public long? UserUpdationId { get; set; }

    public short? IsStatus { get; set; }

    public DateTime? IsAcceptedDate { get; set; }

    public decimal? Amount { get; set; }

    public string? NationalIdcompanyOwner { get; set; }

    public byte? ExOpertaionTypeId { get; set; }

    /// <summary>
    /// اسباب الرفض
    /// </summary>
    public string? NotesReject { get; set; }

    public virtual ICollection<ExCertificatesNewCountry> ExCertificatesNewCountries { get; set; } = new List<ExCertificatesNewCountry>();

    public virtual ICollection<ExCertificatesRequest> ExCertificatesRequests { get; set; } = new List<ExCertificatesRequest>();

    public virtual ICollection<ExCheckRequestCustomsMessage> ExCheckRequestCustomsMessages { get; set; } = new List<ExCheckRequestCustomsMessage>();

    public virtual ICollection<ExCheckRequestDatum> ExCheckRequestData { get; set; } = new List<ExCheckRequestDatum>();

    public virtual ICollection<ExCheckRequestFee> ExCheckRequestFees { get; set; } = new List<ExCheckRequestFee>();

    public virtual ICollection<ExCheckRequestFinalResult> ExCheckRequestFinalResults { get; set; } = new List<ExCheckRequestFinalResult>();

    public virtual ICollection<ExCheckRequestItem> ExCheckRequestItems { get; set; } = new List<ExCheckRequestItem>();

    public virtual ICollection<ExCheckRequestOrganizationDistributionDetial> ExCheckRequestOrganizationDistributionDetials { get; set; } = new List<ExCheckRequestOrganizationDistributionDetial>();

    public virtual ICollection<ExCheckRequestOrganizationDistribution> ExCheckRequestOrganizationDistributions { get; set; } = new List<ExCheckRequestOrganizationDistribution>();

    public virtual ICollection<ExCheckRequestPlace> ExCheckRequestPlaces { get; set; } = new List<ExCheckRequestPlace>();

    public virtual ICollection<ExCheckRequestRefuseReason> ExCheckRequestRefuseReasons { get; set; } = new List<ExCheckRequestRefuseReason>();

    public virtual ICollection<ExCheckRequestVisa> ExCheckRequestVisas { get; set; } = new List<ExCheckRequestVisa>();

    public virtual ICollection<ExChooseSampleDatum> ExChooseSampleData { get; set; } = new List<ExChooseSampleDatum>();

    public virtual ICollection<ExChooseTreatment> ExChooseTreatments { get; set; } = new List<ExChooseTreatment>();

    public virtual ICollection<ExRequestCommittee> ExRequestCommittees { get; set; } = new List<ExRequestCommittee>();

    public virtual Outlet? Outlet { get; set; }

    public virtual ICollection<PalletDataExCheckRequestDistribution> PalletDataExCheckRequestDistributions { get; set; } = new List<PalletDataExCheckRequestDistribution>();

    public virtual ICollection<PalletDataOrganizationDistribution> PalletDataOrganizationDistributions { get; set; } = new List<PalletDataOrganizationDistribution>();
}
