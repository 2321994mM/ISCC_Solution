using ISCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISCC.Infrastructure.Data.Configurations;

public class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
{
    public void Configure(EntityTypeBuilder<Inspection> builder)
    {
        builder.ToTable("Inspections");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.InspectionNumber).IsRequired().HasMaxLength(50);
        builder.Property(i => i.Notes).HasMaxLength(1000);
        builder.HasIndex(i => i.InspectionNumber).IsUnique();
    }
}
