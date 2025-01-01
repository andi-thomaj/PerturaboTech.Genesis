namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class Inspection : BaseEntity
{
    public required GeneticFile GeneticFile { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
    public List<InspectionZone> InspectionsZones { get; set; } = [];
}