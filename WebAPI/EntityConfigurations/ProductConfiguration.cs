using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Entities;

namespace WebAPI.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
        builder.Property(p => p.SubCategoryId).HasColumnName("SubCategoryId");
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(p => p.Name, name:"UK_Products_Name").IsUnique();

        builder.HasOne(p => p.Category);
        builder.HasOne(p => p.SubCategory);
        builder.HasMany(p => p.AttiributeValues).WithMany(av => av.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProductAttiributeValues",
                j => j.HasOne<AttiributeValue>().WithMany().HasForeignKey("AttiributeValueId"),
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId")
            )
                ;
    }
}
