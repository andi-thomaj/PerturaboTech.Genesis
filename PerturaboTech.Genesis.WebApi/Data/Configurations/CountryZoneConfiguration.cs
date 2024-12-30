using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class CountryZoneConfiguration : IEntityTypeConfiguration<CountryZone>
{
    public void Configure(EntityTypeBuilder<CountryZone> builder)
    {
        throw new NotImplementedException();
    }
}