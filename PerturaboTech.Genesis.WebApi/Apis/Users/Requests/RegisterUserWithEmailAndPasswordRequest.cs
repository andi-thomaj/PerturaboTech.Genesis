using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

public record RegisterUserWithEmailAndPasswordRequest(
    string Email,
    string Password,
    string FirstName,
    string? MiddleName,
    string? LastName)
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
        };
    }
}