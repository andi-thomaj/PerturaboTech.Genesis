namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class CountryZone
{
    public Guid CountryId { get; set; }
    public required Country Country { get; set; }
    public Guid ZoneId { get; set; }
    public required Zone Zone { get; set; }
}