using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Data.Entities;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Repository;

namespace PerturaboTech.Genesis.WebApi.Services.Implementations.Repository;

public class UserRepository : IUserRepository
{
    public Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User?> CreateUser(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<User?> UpdateUser(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserById(Guid id)
    {
        throw new NotImplementedException();
    }
}