using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Token)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasIndex(x => x.Token).IsUnique();
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.UserId);
    }
}