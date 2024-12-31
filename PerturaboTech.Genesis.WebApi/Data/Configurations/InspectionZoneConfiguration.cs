using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class InspectionZoneConfiguration : IEntityTypeConfiguration<InspectionZone>
{
    public void Configure(EntityTypeBuilder<InspectionZone> builder)
    {
        builder.HasKey(iz => new { iz.InspectionId, iz.ZoneId });

        // Foreign Key with Inspection
        builder.HasOne(iz => iz.Inspection)
            .WithMany(i => i.InspectionsZones)
            .HasForeignKey(iz => iz.InspectionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign Key with Zone
        builder.HasOne(iz => iz.Zone)
            .WithMany(z => z.InspectionZones)
            .HasForeignKey(iz => iz.ZoneId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}