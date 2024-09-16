namespace WebAPI.Entities.Dtos;

public class CreateProductDto
{
    public int? CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Name { get; set; }
    public IList<CreateProductWithAttiributeDto> CreateProductWithAttiributeDtos { get; set; }
}
