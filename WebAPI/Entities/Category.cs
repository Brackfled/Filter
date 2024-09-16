using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace WebAPI.Entities;

public class Category: Entity<int>
{
    public string Name { get; set; }

    public ICollection<SubCategory>? SubCategories { get; set; } = default!;
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; } = default!;

    public Category()
    {
        Name = string.Empty;
    }

    public Category(string name, ICollection<SubCategory>? subCategories, ICollection<Product>? products)
    {
        Name = name;
        SubCategories = subCategories;
        Products = products;
    }
}
