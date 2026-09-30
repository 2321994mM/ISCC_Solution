using System;
using System.Collections.Generic;

namespace ISCC.Infrastructure.Data.Generated;

/// <summary>
/// افات/حشرات/كائنات
/// </summary>
public partial class ImScientificResearchItemPlantInseketLieble
{
    public long Id { get; set; }

    public long ImScientificResearchId { get; set; }

    /// <summary>
    /// الاسم العلمى
    /// </summary>
    public string ScientificName { get; set; } = null!;

    /// <summary>
    /// السلالة
    /// </summary>
    public short? LiableItemsStrainId { get; set; }

    /// <summary>
    /// الحالة
    /// </summary>
    public int? LiableItemsStatusId { get; set; }

    /// <summary>
    /// نوع العبوة
    /// </summary>
    public short PackageTypeId { get; set; }

    /// <summary>
    /// ملخص الاجراءات
    /// </summary>
    public string ProcedureSummery { get; set; } = null!;

    /// <summary>
    /// نوع الرسالة from systemcode=18
    /// 
    /// </summary>
    public int ResearchTypeId { get; set; }

    /// <summary>
    /// الطور الحيوى
    /// </summary>
    public int BiologicalPhaseId { get; set; }

    public virtual BiologicalPhase BiologicalPhase { get; set; } = null!;

    public virtual ImScientificResearch ImScientificResearch { get; set; } = null!;

    public virtual LiableItemsStatus? LiableItemsStatus { get; set; }

    public virtual ItemCategoriesType? LiableItemsStrain { get; set; }

    public virtual PackageType PackageType { get; set; } = null!;

    public virtual ASystemCode ResearchType { get; set; } = null!;
}
