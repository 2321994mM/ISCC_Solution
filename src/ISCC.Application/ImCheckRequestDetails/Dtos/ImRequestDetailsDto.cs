namespace ISCC.Application.ImCheckRequestDetails.Dtos;

/// <summary>
/// Composite payload of the import check-request details page
/// (<c>Im_CheckRequests/Im_CheckRequestDetails</c>).
/// </summary>
/// <remarks>
/// <para>
/// Ported from the legacy <c>ImRequestDetailsDTO</c> returned by
/// <c>Im_CheckRequestDetailsBLL.GetImCheckRequestDetails</c>. Property names keep the legacy
/// spelling (snake_case where the legacy used it) so the ported view and the legacy view can
/// be compared line by line.
/// </para>
/// <para>
/// A single request drives every collection here: header, ports, customs messages, shipping
/// methods with their items and lots, per-initiator constrains, attachments, linked
/// permissions and the fee breakdown (shifts, samples, treatments).
/// </para>
/// </remarks>
public class ImRequestDetailsDto
{
    public long ID { get; set; }
    public long? Im_CheckRequestData_ID { get; set; }
    public long Im_CheckRequest_ID { get; set; }
    public string? ImCheckRequest_Number { get; set; }

    public string? ImporterName { get; set; }
    public string? OwnerName { get; set; }
    public string? ImporterType { get; set; }
    public string? ImporterAddress { get; set; }
    public string? outletName { get; set; }

    public string? OperationType_Name { get; set; }
    public byte? CompActivityType_ID { get; set; }
    public string? CompanyActivity { get; set; }
    public string? CompanyActivityType { get; set; }
    public decimal? Enrollment_Number { get; set; }
    public DateTime? Enrollment_Start { get; set; }
    public DateTime? Enrollment_End { get; set; }

    public long Importer_ID { get; set; }

    public string? MessageOwner { get; set; }
    public string? MessageOwnerNationalID { get; set; }

    public int ImporterType_Id { get; set; }
    public byte? Shipment_Mean_Id { get; set; }
    public byte? Transport_Mean_Id { get; set; }
    public long? InternationalTransport_Id { get; set; }

    public string? Ship_Name { get; set; }
    public string? InternationalTransport { get; set; }
    public string? Shipment_MeanName { get; set; }
    public string? Transport_MeanName { get; set; }
    public string? ExportCountryName { get; set; }
    public short? TransitCountryId { get; set; }

    public bool? IsAccepted { get; set; }
    public bool? IsPaid { get; set; }
    public bool? IsActive { get; set; }
    public string? Is_Paid_Check { get; set; }

    /// <summary>Companies outside Egypt (from <c>Im_CheckRequestData_Extra</c>).</summary>
    public List<ImporterCompanyDto> ImportersCompanies { get; set; } = new();

    /// <summary>Shipping methods, each carrying its items and lots.</summary>
    public List<CheckRequestShippingDto> checkRequestShipping { get; set; } = new();

    /// <summary>Attachments of the check request itself (<c>A_AttachmentTableNameId = 8</c>).</summary>
    public List<AttachmentDto> Attachments { get; set; } = new();

    /// <summary>Import permissions linked to this request.</summary>
    public List<ListPermissionDto> List_Permission { get; set; } = new();

    /// <summary>Attachments of the linked permissions (<c>A_AttachmentTableNameId = 4</c>).</summary>
    public List<AttachmentPermissionDto> AttachmentPermission { get; set; } = new();

    /// <summary>One row per distinct initiator, carrying its constrains and allowed ports.</summary>
    public List<ItemsCheckReqDto> itemsWithConstrains { get; set; } = new();

    public List<CustomsMessageDto> CustomsMessages { get; set; } = new();

    public List<CompanyActivityDto> _CompanyActivitys { get; set; } = new();
    public List<ContactTypeDto> ImporterContacts { get; set; } = new();

    // الرسوم
    public List<FeesItemDto> Fees_Item_All { get; set; } = new();
    public List<FeesItemShiftDto> Fees_Item_Shift_All { get; set; } = new();
    public decimal? Shift_Item_All { get; set; }
    public decimal? SUM_Shift_Fees_Item { get; set; }

    public List<ListShiftDto> List_Shift { get; set; } = new();
    public List<ListSampleDto> List_Sample { get; set; } = new();
    public List<ListTreatmentDto> List_Treatment { get; set; } = new();
    public List<ListPortDto> List_Port { get; set; } = new();
}

/// <summary>Company outside Egypt (<c>Im_CheckRequestData_Extra</c>).</summary>
public class ImporterCompanyDto
{
    public string? ImporterCompany { get; set; }
    public string? ImporterCompanyAddress { get; set; }
    public string? ImporterCompanyEn { get; set; }
    public string? ImporterCompanyAddressEn { get; set; }
}

/// <summary>One shipping method of the request (حاوية/صب) with its items.</summary>
public class CheckRequestShippingDto
{
    public long ID { get; set; }
    public long? Im_CheckRequest_ID { get; set; }
    public int? containers_ID { get; set; }
    public int? containers_type_ID { get; set; }
    public string? containerName { get; set; }
    public string? containerType { get; set; }
    public string? ShipholdNumber { get; set; }
    public string? ContainerNumber { get; set; }
    public string? NavigationalNumber { get; set; }
    public decimal? Total_Weight { get; set; }
    public decimal? Net_Weight { get; set; }

    public List<ItemsCheckReqDto> Items_checkReq { get; set; } = new();
}

/// <summary>One imported plant item (نباتات طلب الفحص الوارد).</summary>
public class ItemsCheckReqDto
{
    public long ID { get; set; }
    public long? Item_ShortName_ID { get; set; }
    public long? Im_Initiator_ID { get; set; }
    public long? ImcheckReqItem_ID { get; set; }
    public long? ImcheckReqshippedMethod_ID { get; set; }
    public string? qualitiveGroupName { get; set; }
    public string? Item_checkReq_Number { get; set; }
    public decimal? Fees { get; set; }
    public string? ItemName { get; set; }
    public string? ItemShortNameAr { get; set; }
    public string? ItemShortNameEn { get; set; }

    public string? ScientificNameAr { get; set; }
    public string? Status { get; set; }
    public string? Purpose { get; set; }
    public string? subPartName { get; set; }
    public int? SubPart_id { get; set; }

    public string? InitiatorCountry { get; set; }

    public ConstrainsDto? Itemconstrains { get; set; }
    public double? Size { get; set; }
    public int? Package_Count { get; set; }
    public decimal? Package_Weight { get; set; }
    public int? Units_Number { get; set; }
    public string? packageType { get; set; }
    public string? packageMaterial { get; set; }
    public short? packageMaterialID { get; set; }
    public short? packageTypeID { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? Net_Weight { get; set; }

    public string? Order_TextItem { get; set; }
    public string? SubPart_Name { get; set; }

    public List<CategoriesLotsDto> ItemCategories_lots { get; set; } = new();
}

/// <summary>One lot/category row of an item (تقسيم لوط وأصناف).</summary>
public class CategoriesLotsDto
{
    public long ID { get; set; }
    public string? packageMaterialName { get; set; }
    public string? packageMaterial { get; set; }
    public short? packageMaterialID { get; set; }
    public long? Im_checkReqItems_ID { get; set; }
    public long? Im_checkReqItemsCategory_ID { get; set; }
    public string? categoryName { get; set; }
    public double? Size { get; set; }
    public int? Package_Count { get; set; }
    public decimal? Package_Weight { get; set; }
    public int? Units_Number { get; set; }
    public string? packageType { get; set; }
    public short? packageTypeID { get; set; }
    public decimal? GrossWeight { get; set; }
    public string? Order_TextLot { get; set; }
    public string? RegisterReason { get; set; }
    public long? ItemCategory_ID { get; set; }
    public string? ItemCategory { get; set; }
    public string? ItemCategoryGroup { get; set; }
    public string? RecordedOrNot { get; set; }
    public string? Reason_Entry { get; set; }
    public decimal? Net_Weight { get; set; }
    public decimal? Net_Weight_Final { get; set; }
    public string? Lot_Number { get; set; }
    public bool? IsAccepted { get; set; }
    public string? RejectReason { get; set; }
    public decimal? Based_Weight { get; set; }
    public decimal? Package_Based_Weight { get; set; }
    public decimal? Package_Net_Weight { get; set; }
    public string? Number_Wooden_Package { get; set; }
    public string? Grower_Number { get; set; }
    public string? Waybill { get; set; }
}

/// <summary>Constrain texts and allowed arrival ports for one initiator.</summary>
public class ConstrainsDto
{
    public List<string?> texts_Ar { get; set; } = new();
    public List<string?> text_En { get; set; } = new();
    public List<string?> InSide_Certificate_Ar { get; set; } = new();
    public List<string?> InSide_Certificate_En { get; set; } = new();
    public List<ConstrainPortDto> itemConstrainPorts { get; set; } = new();
}

/// <summary>An allowed arrival port of a constrain.</summary>
public class ConstrainPortDto
{
    public int? portId { get; set; }
    public byte? portTypeId { get; set; }
    public string? portType { get; set; }
    public string? portName { get; set; }
}

/// <summary>Attachment of the check request itself.</summary>
public class AttachmentDto
{
    public string? Attachment_Number { get; set; }
    public string? AttachmentPath { get; set; }
    public string? Attachment_TypeName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Attachment_Name { get; set; }
}

/// <summary>Attachment of a linked import permission.</summary>
public class AttachmentPermissionDto
{
    public string? AttachmentPath { get; set; }
    public string? Attachment_Number { get; set; }
    public string? Attachment_TypeName { get; set; }
    public string? Attachment_Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

/// <summary>Linked import permission (إذن استيراد).</summary>
public class ListPermissionDto
{
    public long ID { get; set; }
    public decimal? ImPermission_Number { get; set; }
}

/// <summary>One port row of the request (شحن / عبور / وصول).</summary>
public class ListPortDto
{
    public int ReqPortType_ID { get; set; }
    public string? TransportPortType { get; set; }
    public string? ExportCountryName { get; set; }
    public string? ArrivePortName { get; set; }
    public string? TransportPortName { get; set; }
    public string? ArrivePortType { get; set; }
    public string? TransitPortType { get; set; }
    public string? TransitPort { get; set; }
    public string? TransitCountry { get; set; }
    public string? govNameAR { get; set; }
    public string? govNameEN { get; set; }
}

/// <summary>Customs message (البيانات الجمركية) of the request.</summary>
public class CustomsMessageDto
{
    public long? Im_CheckRequest_ID { get; set; }
    public string? Customs_Certificate_Number { get; set; }
    public DateTime? Certification_Date { get; set; }
    public DateTime? Shipment_Date { get; set; }
    public DateTime? Arrival_Date { get; set; }
    public string? Certificate_Number_Each_Product { get; set; }
    public string? Manifest_Number { get; set; }
    public long? Shipping_Agency_ID { get; set; }
    public string? Shipping_Agency_Name { get; set; }
    public byte? OperationType_ID { get; set; }
    public string? OperationType_Name { get; set; }
}

/// <summary>A company activity / a public-organization responsible person block.</summary>
public class CompanyActivityDto
{
    public string? CompActivityType__Name { get; set; }
    public string? Enrollment_Name { get; set; }
    public decimal? Enrollment_Number { get; set; }
    public DateTime? Enrollment_Start { get; set; }
    public DateTime? Enrollment_End { get; set; }
    public string? Enrollment_type_Name { get; set; }
    public string? PersonResponsible_IDNumber { get; set; }
    public string? PersonResponsible_Name { get; set; }
    public string? Person_Responsible_Job { get; set; }
    public string? Person_Responsible_Address { get; set; }
}

/// <summary>A contact value of the importer (phone/email/…).</summary>
public class ContactTypeDto
{
    public string? Name_Ar { get; set; }
    public string? Value { get; set; }
}

/// <summary>Fee row per imported item.</summary>
public class FeesItemDto
{
    public long? ID { get; set; }
    public string? ItemShortName { get; set; }
    public string? ItemName { get; set; }
    public decimal? Fees { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? Net_Weight { get; set; }
    public decimal? Shift_Item_All { get; set; }
    public decimal? SUM_Shift_Fees_Item { get; set; }
    public string? Is_Paid_Items { get; set; }
}

/// <summary>Committee shift fee row (رسم النوبتجية).</summary>
public class FeesItemShiftDto
{
    public decimal? total_Per_Shift { get; set; }
    public decimal? Count_Per_Shift { get; set; }
    public decimal? Amount_Per_Shift { get; set; }
}

/// <summary>One shift name aggregated across the request.</summary>
public class ListShiftDto
{
    public long? ID { get; set; }
    public string? Shift_Name { get; set; }
    public decimal? Shift_Count { get; set; }
    public decimal? Shift_Amount { get; set; }
    public decimal? Shift_Sum_All { get; set; }
    public string? Is_Paid_Shift { get; set; }
}

/// <summary>Sample fee row (رسم السحب).</summary>
public class ListSampleDto
{
    public long? ID { get; set; }
    public string? Laboratory_Name { get; set; }
    public string? Sample_Name { get; set; }
    public decimal? Sample_Amount { get; set; }
    public decimal? Sample_Count { get; set; }
    public decimal? Sample_Sum_All { get; set; }
    public string? Sample_BarCode { get; set; }
    public string? Is_Total { get; set; }
    public string? Is_Paid_Sample { get; set; }
}

/// <summary>Treatment fee row (رسم المعالجة).</summary>
public class ListTreatmentDto
{
    public long ID { get; set; }
    public long Im_RequestCommittee_ID { get; set; }
    public string? TreatmentMethod_Name { get; set; }
    public string? TreatmentType_Name { get; set; }
    public string? TreatmentMat_Name { get; set; }
    public decimal? Treatment_Amount { get; set; }
    public string? Is_Paid_Treatment { get; set; }
}

/// <summary>Input of the "save refuse reasons" action.</summary>
public class ReasonsListReqIdDto
{
    public long checkReqId { get; set; }
    public string? checkRequestNumber { get; set; }
    public DateTime User_Creation_Date { get; set; }
    public long User_Creation_Id { get; set; }
    public List<short> refuseReasonsIds { get; set; } = new();
}

/// <summary>Input of the "accept request" action.</summary>
public class ImCheckRequestDto
{
    public long ID { get; set; }
    public bool? IsAccepted { get; set; }
    public DateTime? IsAccepted_Date { get; set; }
    public bool? IsActive { get; set; }
    public short? User_Updation_Id { get; set; }
    public DateTime? User_Updation_Date { get; set; }
}

/// <summary>Input of the "save item fees" action.</summary>
public class ItemFeesDto
{
    public long? ImcheckReqItem_ID { get; set; }
    public decimal? Fees { get; set; }
    public short? User_Updation_Id { get; set; }
    public DateTime? User_Updation_Date { get; set; }
}

/// <summary>A refuse-reason option (value + display text) for the refuse dropdown.</summary>
public class RefuseReasonOptionDto
{
    public string? DisplayText { get; set; }
    public short? Value { get; set; }
}
