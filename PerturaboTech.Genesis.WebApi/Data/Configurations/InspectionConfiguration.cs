using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
{
    public void Configure(EntityTypeBuilder<Inspection> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.GeneticFile)
            .WithOne(x => x.Inspection)
            .HasForeignKey<GeneticFile>(x => x.InspectionId);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Inspections)
            .HasForeignKey(x => x.UserId);
    }
}