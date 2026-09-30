using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// المناشىء
/// </summary>
public partial class ImInitiator
{
    public long Id { get; set; }

    public short? CountryId { get; set; }

    public long? ItemShortNameId { get; set; }

    /// <summary>
    /// المجموعة النوعية
    /// </summary>
    public short? QualitativeGroupId { get; set; }

    /// <summary>
    /// حالة المنشأ
    /// from systemcode 16
    /// 
    /// </summary>
    public int InitiatorStatus { get; set; }

    public bool IsActive { get; set; }

    public string? ForbiddenReason { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short UserCreationId { get; set; }

    public DateTime UserCreationDate { get; set; }

    public string? AttachmentPath { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<ImCheckRequestItem> ImCheckRequestItems { get; set; } = new List<ImCheckRequestItem>();

    public virtual ICollection<ImConstrainInitiatorText> ImConstrainInitiatorTexts { get; set; } = new List<ImConstrainInitiatorText>();

    public virtual ICollection<ImPermissionItem> ImPermissionItems { get; set; } = new List<ImPermissionItem>();

    public virtual ItemShortName? ItemShortName { get; set; }
}
