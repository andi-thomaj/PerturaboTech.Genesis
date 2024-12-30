namespace PerturaboTech.Genesis.WebApi.Data.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsDeleted { get; set; }
    public int LoginAttemptsCount { get; set; }
    public string? FrontendTheme { get; set; }
    public List<Inspection> Inspections { get; set; } = [];
}