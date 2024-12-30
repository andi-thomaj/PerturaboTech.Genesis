using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Apis.Users.Responses;
using PerturaboTech.Genesis.WebApi.Helpers;

namespace PerturaboTech.Genesis.WebApi.Services.Abstractions;

public interface IUserService
{
    Task<Result<GetUserByEmailResponse>> GetUserByEmail(string email);
    Task<Result<UpdateUserResponse>> UpdateUser(UpdateUserRequest request);
    Task<Result> DeleteUserById(Guid id);
    Task<Result<LoginWithRefreshTokenResponse>> LoginWithRefreshToken(LoginWithRefreshTokenRequest request);
    Task<Result<LoginWithEmailAndPasswordResponse>> LoginWithEmailAndPassword(LoginWithEmailAndPasswordRequest request);
    Task<Result<RegisterUserWithEmailAndPasswordResponse>> RegisterUserWithEmailAndPassword(
        RegisterUserWithEmailAndPasswordRequest request);
}