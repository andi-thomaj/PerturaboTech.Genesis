namespace PerturaboTech.Genesis.Domain.Entities;

public class User
{
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsBlocked { get; set; }
    public bool IsDeleted { get; set; }
    public int LoginAttemptsCount { get; set; }
}