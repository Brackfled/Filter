using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Entities;

namespace WebAPI.EntityConfigurations;

public class AttiributeConfiguration : IEntityTypeConfiguration<Attiribute>
{
    public void Configure(EntityTypeBuilder<Attiribute> builder)
    {
        builder.ToTable("Attiributes").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(a => a.Name, name:"UK_Attiributes_Name").IsUnique();

        builder.HasMany(a => a.AttiributeValues);
    }
}
