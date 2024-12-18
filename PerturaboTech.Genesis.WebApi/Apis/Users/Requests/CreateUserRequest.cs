using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

public record CreateUserRequest(
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Password,
    string PictureUrl,
    string FrontendTheme)
{
    public User GetUserEntity()
    {
        return new User
        {
            FirstName = FirstName,
            MiddleName = MiddleName,
            LastName = LastName,
            Email = Email,
            Password = Password,
            PictureUrl = PictureUrl,
            FrontendTheme = FrontendTheme
        };
    }
}