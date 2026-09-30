using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class WebsiteTypeDetail
{
    public int Id { get; set; }

    public string? TitleAr { get; set; }

    public string? TitleEn { get; set; }

    public string? DescAr { get; set; }

    public string? DescEn { get; set; }

    public string? Filepath { get; set; }

    public int? WebsitetypeId { get; set; }

    public DateTime? Date { get; set; }

    public short? UserUpdationId { get; set; }

    public DateTime? UserUpdationDate { get; set; }

    public short? UserDeletionId { get; set; }

    public DateTime? UserDeletionDate { get; set; }

    public short? UserCreationId { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public bool? IsActive { get; set; }

    public string? LinkUrl { get; set; }

    public virtual Websitetype? Websitetype { get; set; }
}
