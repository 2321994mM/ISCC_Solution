using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class AUserLogin
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateTime LoginDate { get; set; }

    public DateTime? LogOutDate { get; set; }

    public string AccessToken { get; set; } = null!;
}
