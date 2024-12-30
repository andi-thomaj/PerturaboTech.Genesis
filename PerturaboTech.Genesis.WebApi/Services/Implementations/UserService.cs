using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Apis.Users.Responses;
using PerturaboTech.Genesis.WebApi.Data.Entities;
using PerturaboTech.Genesis.WebApi.Helpers;
using PerturaboTech.Genesis.WebApi.Services.Abstractions;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Infrastructure;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Repository;

namespace PerturaboTech.Genesis.WebApi.Services.Implementations;

public class UserService(IUserRepository userRepository, ITokenProvider tokenProvider) : IUserService
{
    public async Task<Result<GetUserByEmailResponse>> GetUserByEmail(string email)
    {
        try
        {
            var user = await userRepository.GetUserByEmail(email);

            if (user is null)
            {
                return new Result<GetUserByEmailResponse>(null, false, Error.NotFound(nameof(GetUserByEmail), $"User {email} was not found"));
            }

            return new Result<GetUserByEmailResponse>(new GetUserByEmailResponse(user), true, Error.None);
        }
        catch (Exception e)
        {
            return new Result<GetUserByEmailResponse>(null, false, Error.Problem(nameof(GetUserByEmail), e.Message));
        }
    }

    public async Task<Result<CreateUserResponse>> CreateUser(CreateUserRequest request)
    {
        try
        {
            var user = await userRepository.CreateUser(request);
            
            if (user is null)
            {
                return new Result<CreateUserResponse>(null, false, Error.Conflict(nameof(CreateUser), $"User {request.Email} already exists"));
            }

            var token = tokenProvider.GenerateToken(user);
            return new Result<CreateUserResponse>(new CreateUserResponse(user, token), true, Error.None);
        }
        catch (Exception e)
        {
            return new Result<CreateUserResponse>(null, false, Error.Problem(nameof(CreateUser), e.Message));
        }
    }

    public async Task<Result<UpdateUserResponse>> UpdateUser(UpdateUserRequest request)
    {
        try
        {
            var user = await userRepository.UpdateUser(request);

            if (user is null)
            {
                return new Result<UpdateUserResponse>(null, false, Error.NotFound(nameof(UpdateUser), $"User {request.FirstName} {request.LastName} was not found"));
            }
            
            return new Result<UpdateUserResponse>(new UpdateUserResponse(user), true, Error.None);
        }
        catch (Exception e)
        {
            return new Result<UpdateUserResponse>(null, false, Error.Problem(nameof(UpdateUser), e.Message));
        }
    }

    public async Task<Result> DeleteUserById(Guid id)
    {
        try
        {
            var isDeleted = await userRepository.DeleteUserById(id);

            if (!isDeleted)
            {
                return new Result(false, Error.NotFound(nameof(DeleteUserById), $"User {id} was not deleted"));
            }
            
            return new Result(true, Error.None);
        }
        catch (Exception e)
        {
            return new Result(false, Error.Problem(nameof(DeleteUserById), e.Message));
        }
    }

    public async Task<Result<LoginWithRefreshTokenResponse>> LoginWithRefreshToken(LoginWithRefreshTokenRequest request)
    {
        RefreshToken? refreshToken = await userRepository.GetRefreshToken(request.RefreshToken);

        if (refreshToken is null || refreshToken.ExpiresOnUtc < DateTime.UtcNow)
        {
            return new Result<LoginWithRefreshTokenResponse>(null,false, Error.NotFound(nameof(LoginWithRefreshToken), "Refresh token is invalid or expired"));
        }

        string jwt = tokenProvider.GenerateToken(refreshToken.User);

        var newRefreshToken = await userRepository.CreateRefreshToken(refreshToken.User.Id);

        return new Result<LoginWithRefreshTokenResponse>(new LoginWithRefreshTokenResponse(jwt, newRefreshToken.Token),
            true, Error.None);
    }

    public async Task<Result<LoginWithEmailAndPasswordResponse>> LoginWithEmailAndPassword(
        LoginWithEmailAndPasswordRequest request)
    {
        var user = await userRepository.GetUserByEmail(request.Email);

        if (user is null)
        {
            return new Result<LoginWithEmailAndPasswordResponse>(null, false, Error.NotFound($"{nameof(LoginWithEmailAndPassword)}", $"User with email: {request.Email} was not found"));
        }

        if (user.Password != request.Password)
        {
            return new Result<LoginWithEmailAndPasswordResponse>(null, false, Error.Unauthorized($"{nameof(LoginWithEmailAndPassword)}", "Invalid password"));
        }
        
        var jwt = tokenProvider.GenerateToken(user);
        var refreshToken = await userRepository.CreateRefreshToken(user.Id);
        
        return new Result<LoginWithEmailAndPasswordResponse>(new LoginWithEmailAndPasswordResponse(jwt, refreshToken.Token), true, Error.None);
    }
    
    
}