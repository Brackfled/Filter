using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Entities;

namespace WebAPI.EntityConfigurations;

public class AttiributeValueConfiguration : IEntityTypeConfiguration<AttiributeValue>
{
    public void Configure(EntityTypeBuilder<AttiributeValue> builder)
    {
        builder.ToTable("AttiributeValues").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.AttiributeId).HasColumnName("AttiributeId").IsRequired();
        builder.Property(p => p.Value).HasColumnName("Value").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(av => av.Attiribute);
        builder.HasMany(av => av.Products);
    }
}
