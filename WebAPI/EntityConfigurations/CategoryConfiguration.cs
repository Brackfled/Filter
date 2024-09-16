using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Entities;

namespace WebAPI.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(a => a.Name, name: "UK_Categories_Name").IsUnique();

        builder.HasMany(c => c.SubCategories).WithOne(sc => sc.Category).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(c => c.Products).WithOne(sc => sc.Category).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.SetNull);
    }
}
