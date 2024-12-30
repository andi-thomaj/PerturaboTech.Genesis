namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<Zone> Zones { get; set; } = [];
}