namespace ISCC.Api.Application.Areas.DE_Outlets.Models;

public sealed class ContactInputModel
{
    public int? Id { get; set; }

    public byte? ContactTypeId { get; set; }

    public string? Value { get; set; }
}
