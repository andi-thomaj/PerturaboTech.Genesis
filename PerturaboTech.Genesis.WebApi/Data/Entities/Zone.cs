namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class Zone : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid CountryId { get; set; }
    public required Country Country { get; set; }
    public List<InspectionZone> InspectionZones { get; set; } = [];
}