using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// النبات/ منتج
/// </summary>
public partial class ImScientificResearchItemPlantProduct
{
    public long Id { get; set; }

    public long ImScientificResearchId { get; set; }

    /// <summary>
    /// اسم النبات او المنتج
    /// </summary>
    public string ProdPlantName { get; set; } = null!;

    /// <summary>
    /// حالة المنتج او النبات
    /// </summary>
    public int ProductStatusId { get; set; }

    /// <summary>
    /// اسم الجزء النباتى فى حالة النبات
    /// </summary>
    public string PlantPartName { get; set; } = null!;

    /// <summary>
    /// الاسم العلمى
    /// </summary>
    public string ScientificName { get; set; } = null!;

    /// <summary>
    /// ملخص الاجراءات
    /// </summary>
    public string ProcedureSummery { get; set; } = null!;

    /// <summary>
    /// الأصناف الزراعية
    /// </summary>
    public string? PlantCategories { get; set; }

    /// <summary>
    /// نوع الرسالة from systemcode=18
    /// 
    /// </summary>
    public int ResearchTypeId { get; set; }

    public virtual ImScientificResearch ImScientificResearch { get; set; } = null!;

    public virtual ItemStatus ProductStatus { get; set; } = null!;

    public virtual ASystemCode ResearchType { get; set; } = null!;
}
