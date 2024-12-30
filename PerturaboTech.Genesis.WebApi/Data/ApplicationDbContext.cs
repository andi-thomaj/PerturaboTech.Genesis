using Microsoft.EntityFrameworkCore;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Zone> Zones { get; set; }
    public DbSet<CountryZone> CountriesZones { get; set; }
    public DbSet<GeneticFile> GeneticFiles { get; set; }
    public DbSet<Inspection> Inspections { get; set; }
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}