namespace WebAPI.Entities.Dtos;

public class CategoriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; } = default!;
}
