namespace PerturaboTech.Genesis.Shared.Configurations;

public class DatabaseOptions
{
    public const string SectionName = nameof(DatabaseOptions);
    public string ConnectionString { get; set; } = string.Empty;
}