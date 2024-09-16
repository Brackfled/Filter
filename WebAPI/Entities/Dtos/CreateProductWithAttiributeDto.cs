namespace WebAPI.Entities.Dtos;

public class CreateProductWithAttiributeDto
{
    public int? AttiributeId { get; set; }
    public string? AttiributeName { get; set; }
    public int? AttiributeValueId { get; set; }
    public string? Value { get; set; }
}
