using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// النتيجه
/// </summary>
public partial class ImCommitteeResult
{
    public long Id { get; set; }

    /// <summary>
    /// كود اساسيات اللجنه
    /// </summary>
    public long CommitteeId { get; set; }

    public long ImRequestItemId { get; set; }

    /// <summary>
    /// null for the whole request  /  كود بيانات الدفعه
    /// </summary>
    public long? LotDataId { get; set; }

    public long? EmployeeId { get; set; }

    public byte? CommitteeResultTypeId { get; set; }

    public DateTime? Date { get; set; }

    /// <summary>
    /// null-&gt;exporter not take action 0 if exporter doesn&apos;t accept else 1
    /// </summary>
    public bool? IsAdminResult { get; set; }

    /// <summary>
    /// Admin Note
    /// </summary>
    public string? AdminFinalResultNote { get; set; }

    /// <summary>
    /// العدد
    /// </summary>
    public double? QuantitySize { get; set; }

    /// <summary>
    /// الوزن
    /// </summary>
    public double? Weight { get; set; }

    public string? Notes { get; set; }

    /// <summary>
    /// (0) in the case of all,(1) in the case of the part   في حاله الجزئي او الكلي
    /// </summary>
    public bool? IsTotal { get; set; }

    /// <summary>
    /// الاسم المختصر
    /// </summary>
    public long? ItemShortNameId { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    /// <summary>
    /// في حاله الفحص لو كلي واتحول الي جزئي
    /// </summary>
    public bool? IsTotalAndroid { get; set; }

    public virtual ICollection<AAttachmentDataImCommitteeResultInfection> AAttachmentDataImCommitteeResultInfections { get; set; } = new List<AAttachmentDataImCommitteeResultInfection>();

    public virtual ImRequestCommittee Committee { get; set; } = null!;

    public virtual CommitteeResultType? CommitteeResultType { get; set; }

    public virtual ICollection<ImCommitteeResultConfirm> ImCommitteeResultConfirms { get; set; } = new List<ImCommitteeResultConfirm>();

    public virtual ICollection<ImCommitteeResultInfection> ImCommitteeResultInfections { get; set; } = new List<ImCommitteeResultInfection>();

    public virtual ItemShortName? ItemShortName { get; set; }
}
