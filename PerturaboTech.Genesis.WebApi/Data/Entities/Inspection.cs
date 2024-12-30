namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class Inspection : BaseEntity
{
    public Guid GeneticFileId { get; set; }
    public required GeneticFile GeneticFile { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public List<CountryZone> CountriesZones { get; set; } = [];
}