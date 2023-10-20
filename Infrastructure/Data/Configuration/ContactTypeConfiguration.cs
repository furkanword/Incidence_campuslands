using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
{
    public void Configure(EntityTypeBuilder<ContactType> builder)
    {
        builder.ToTable("ContactType");
        builder.Property(p => p.Id_ContactType).IsRequired();
        builder.Property(p => p.Name_Contact).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description_ContactType).IsRequired().HasMaxLength(100);
    }
}