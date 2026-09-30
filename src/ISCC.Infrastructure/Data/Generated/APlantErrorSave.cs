using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

public partial class APlantErrorSave
{
    public long Id { get; set; }

    public string PageName { get; set; } = null!;

    public string ErrorMessage { get; set; } = null!;

    public DateTime Date { get; set; }

    public string FunctionName { get; set; } = null!;

    public string UserIp { get; set; } = null!;

    /// <summary>
    /// 1-&gt;web, 0-&gt;android
    /// </summary>
    public bool IsWeb { get; set; }
}
