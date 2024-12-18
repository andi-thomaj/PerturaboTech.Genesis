using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Apis.Users.Responses;
using PerturaboTech.Genesis.WebApi.Helpers;
using PerturaboTech.Genesis.WebApi.Services.Abstractions;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Repository;

namespace PerturaboTech.Genesis.WebApi.Services.Implementations;

public class UserService(IUserRepository userRepository) : IUserService
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
            
            return new Result<CreateUserResponse>(new CreateUserResponse(user), true, Error.None);
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
}