using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class GeneticFileConfiguration : IEntityTypeConfiguration<GeneticFile>
{
    public void Configure(EntityTypeBuilder<GeneticFile> builder)
    {
        throw new NotImplementedException();
    }
}