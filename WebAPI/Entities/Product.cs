using NArchitecture.Core.Persistence.Repositories;

namespace WebAPI.Entities;

public class Product : Entity<int>
{
    public int? CategoryId { get; set; }
    public int? SubCategoryId { get; set; }
    public string Name { get; set; }

    public virtual Category? Category { get; set; }
    public virtual SubCategory? SubCategory { get; set; }
    public ICollection<AttiributeValue>? AttiributeValues { get; set; }

    public Product()
    {
        Name = string.Empty;
    }

    public Product(int? categoryId, int? subCategoryId, string name, Category? category, SubCategory? subCategory, ICollection<AttiributeValue>? attiributeValues)
    {
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Name = name;
        Category = category;
        SubCategory = subCategory;
        AttiributeValues = attiributeValues;
    }
}