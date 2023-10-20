using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.Property(p => p.Id_State).IsRequired();
            builder.Property(p => p.Description_State).IsRequired().HasMaxLength(100);
        }
}