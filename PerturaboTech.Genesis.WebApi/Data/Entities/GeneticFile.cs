namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class GeneticFile : BaseEntity
{
    public byte[] FileData { get; set; } = [];
    public string FileName { get; set; } = string.Empty;
    public string FileExtension { get; set; } = string.Empty;
    public Guid InspectionId { get; set; }
    public required Inspection Inspection { get; set; }
}