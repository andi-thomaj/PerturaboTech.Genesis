namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class InspectionZone : BaseEntity
{
    public Guid InspectionId { get; set; }
    public required Inspection Inspection { get; set; }
    public Guid ZoneId { get; set; }
    public required Zone Zone { get; set; }
}