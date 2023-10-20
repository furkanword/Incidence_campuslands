using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PeripheralConfiguration : IEntityTypeConfiguration<Peripheral>
{
    public void Configure(EntityTypeBuilder<Peripheral> builder)
    {
        builder.ToTable("Peripheral");
        builder.Property(p => p.Id_Peripheral).IsRequired();
        builder.Property(p => p.Name_Peripheral).IsRequired().HasMaxLength(50);


         builder.HasOne(y => y.DetailIncidence)
            .WithMany(l => l.Peripherals)
            .HasForeignKey(z => z.Id_Peripheral)
            .IsRequired();
    }
}