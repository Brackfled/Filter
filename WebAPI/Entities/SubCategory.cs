using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace WebAPI.Entities;

public class SubCategory : Entity<int>
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }

    public virtual Category? Category { get; set; }
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; } = default!;

    public SubCategory()
    {
        Name = string.Empty;
    }

    public SubCategory(int? categoryId, string name, Category? category, ICollection<Product>? products)
    {
        CategoryId = categoryId;
        Name = name;
        Category = category;
        Products = products;
    }
}
