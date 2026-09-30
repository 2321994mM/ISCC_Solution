using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class UserType
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsCompany { get; set; }

    public long Idsource { get; set; }

    public bool? Isadmin { get; set; }

    public int? UserType1 { get; set; }

    public long? UserDeleteId { get; set; }

    public DateTime? UserDeleteDate { get; set; }

    public long? UserUpdataId { get; set; }

    public DateTime? UserUpdataDate { get; set; }
}
