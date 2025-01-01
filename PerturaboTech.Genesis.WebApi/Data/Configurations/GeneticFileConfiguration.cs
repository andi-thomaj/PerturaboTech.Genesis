using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class GeneticFileConfiguration : IEntityTypeConfiguration<GeneticFile>
{
    public void Configure(EntityTypeBuilder<GeneticFile> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.FileData)
            .IsRequired();
        
        builder
            .Property(x => x.FileName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.FileExtension)
            .HasMaxLength(50)
            .IsRequired();
    }
}