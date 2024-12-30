using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

internal sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.MiddleName)
            .HasMaxLength(50)
            .IsRequired(false);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired(false);

        builder
            .Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.LoginAttemptsCount)
            .IsRequired();

        builder
            .Property(x => x.IsBlocked)
            .IsRequired();

        builder
            .Property(x => x.IsDeleted)
            .IsRequired();

        builder
            .Property(x => x.PictureUrl)
            .IsRequired(false);
        
        builder.HasIndex(x => x.Email).IsUnique();
    }
}