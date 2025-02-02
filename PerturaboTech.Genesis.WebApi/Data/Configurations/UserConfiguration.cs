using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(x => x.MiddleName)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(x => x.Username)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Password)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(x => x.IsBlocked)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(x => x.LoginAttemptsCount)
            .HasDefaultValue(0)
            .IsRequired();
    }
}