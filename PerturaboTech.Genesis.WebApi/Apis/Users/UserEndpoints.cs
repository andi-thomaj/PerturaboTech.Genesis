using Microsoft.AspNetCore.Http.HttpResults;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Apis.Users.Responses;
using PerturaboTech.Genesis.WebApi.Apis.Users.Validations;
using PerturaboTech.Genesis.WebApi.Helpers;
using PerturaboTech.Genesis.WebApi.Services.Abstractions;

namespace PerturaboTech.Genesis.WebApi.Apis.Users;

public static class UserEndpoints
{
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder builder)
        {
            var routeGroupBuilder = builder.MapGroup("api/users")
                .WithOpenApi()
                .RequireAuthorization();

            routeGroupBuilder.MapGet("{email}", GetUserByEmail);
            routeGroupBuilder.MapPut(string.Empty, UpdateUser);
            routeGroupBuilder.MapDelete("{id:guid}", DeleteUserById);
            routeGroupBuilder.MapPost("login", LoginWithEmailAndPassword)
                .AllowAnonymous();
            routeGroupBuilder.MapPost("refresh-token", LoginWithRefreshToken);
            routeGroupBuilder.MapPost("register", RegisterUserWithEmailAndPassword)
                .AllowAnonymous();

            return builder;
        }

        private static async Task<Results<Ok<GetUserByEmailResponse>, NotFound<Error>, BadRequest<Error>, Conflict<Error>>> GetUserByEmail(string email,
            IUserService userService)
        {
            GetUserByEmailRequestValidator validator = new();
            var validationResult = await validator.ValidateAsync(new GetUserByEmailRequest(email));
            if (!validationResult.IsValid)
            {
                return TypedResults.BadRequest(Error.FluentValidationError(nameof(GetUserByEmail), validationResult.Errors));
            }
        
            var result = await userService.GetUserByEmail(email);

            if (result.IsFailure)
            {
                return result.Error.Type switch
                {
                    ErrorType.Conflict => TypedResults.Conflict(result.Error),
                    ErrorType.NotFound => TypedResults.NotFound(result.Error),
                    _ => TypedResults.BadRequest(result.Error)
                };
            }

            return TypedResults.Ok(result.Value);
        }
        
    private static async Task<Results<Ok<UpdateUserResponse>, NotFound<Error>, BadRequest<Error>>> UpdateUser(
        UpdateUserRequest request, IUserService userService)
    {
        UpdateUserRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(Error.FluentValidationError(nameof(UpdateUser), validationResult.Errors));
        }
        
        var result = await userService.UpdateUser(request);
        
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }
    
        return TypedResults.Ok(result.Value);
    }
    
    private static async Task<Results<Ok, NotFound<Error>, BadRequest<Error>>> DeleteUserById(Guid id,
        IUserService userService)
    {
        var result = await userService.DeleteUserById(id);
        
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }
        
        return TypedResults.Ok();
    }
    
    private static async Task<Results<Ok<LoginWithEmailAndPasswordResponse>, NotFound<Error>, BadRequest<Error>>> LoginWithEmailAndPassword(LoginWithEmailAndPasswordRequest request,
        IUserService userService)
    {
        var result = await userService.LoginWithEmailAndPassword(request);
        
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }
        
        return TypedResults.Ok(result.Value);
    }
    
    private static async Task<Results<Ok<LoginWithRefreshTokenResponse>, NotFound<Error>, BadRequest<Error>>> LoginWithRefreshToken(LoginWithRefreshTokenRequest request,
        IUserService userService)
    {
        var result = await userService.LoginWithRefreshToken(request);
        
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }
        
        return TypedResults.Ok(result.Value);
    }
    
    private static async Task<Results<Ok<RegisterUserWithEmailAndPasswordResponse>, Conflict<Error>, NotFound<Error>, BadRequest<Error>>> RegisterUserWithEmailAndPassword(RegisterUserWithEmailAndPasswordRequest request,
        IUserService userService)
    {
        RegisterUserWithEmailAndPasswordRequestValidator validator = new();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(Error.FluentValidationError(nameof(RegisterUserWithEmailAndPassword), validationResult.Errors));
        }
        
        var result = await userService.RegisterUserWithEmailAndPassword(request);
    
        if (result.IsFailure)
        {
            return result.Error.Type switch
            {
                ErrorType.Conflict => TypedResults.Conflict(result.Error),
                ErrorType.NotFound => TypedResults.NotFound(result.Error),
                _ => TypedResults.BadRequest(result.Error)
            };
        }
    
        return TypedResults.Ok(result.Value);
    }
}