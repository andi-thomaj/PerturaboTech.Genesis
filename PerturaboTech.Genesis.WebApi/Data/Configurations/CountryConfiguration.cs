using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();

        // One-to-Many: Country -> Zone
        builder.HasMany(c => c.Zones)
            .WithOne(z => z.Country)
            .HasForeignKey(z => z.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}