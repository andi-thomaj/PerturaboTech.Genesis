using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

public record UpdateUserRequest(Guid Id, string FirstName, string MiddleName, string LastName, string FrontendTheme)
{
    public User GetUserEntity()
    {
        return new User
        {
            Id = Id,
            FirstName = FirstName,
            MiddleName = MiddleName,
            LastName = LastName,
            FrontendTheme = FrontendTheme
        };
    }
}