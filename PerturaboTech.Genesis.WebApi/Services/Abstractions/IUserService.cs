using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Apis.Users.Responses;
using PerturaboTech.Genesis.WebApi.Helpers;

namespace PerturaboTech.Genesis.WebApi.Services.Abstractions;

public interface IUserService
{
    Task<Result<GetUserByEmailResponse>> GetUserByEmail(string email);
    Task<Result<CreateUserResponse>> CreateUser(CreateUserRequest request);
    Task<Result<UpdateUserResponse>> UpdateUser(UpdateUserRequest request);
    Task<Result> DeleteUserById(Guid id);
}