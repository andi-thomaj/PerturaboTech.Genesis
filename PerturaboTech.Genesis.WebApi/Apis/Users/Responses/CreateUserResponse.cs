using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Responses;

public record CreateUserResponse
{
    public CreateUserResponse(User user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        MiddleName = user.MiddleName;
        LastName = user.LastName;
        Email = user.Email;
        GooglePictureUrl = user.PictureUrl;
        FrontendTheme = user.FrontendTheme;
        IsBlocked = user.IsBlocked;
        IsDeleted = user.IsDeleted;
        CreatedAt = user.CreatedAt;
        
    }
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string? LastName { get; init; }
    public string Email { get; init; }
    public string? GooglePictureUrl { get; init; }
    public string? FrontendTheme { get; init; }
    public bool IsBlocked { get; init; }
    public bool IsDeleted { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}