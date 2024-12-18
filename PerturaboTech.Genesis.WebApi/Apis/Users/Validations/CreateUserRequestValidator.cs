using FluentValidation;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Validations;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(request => request.FirstName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .MinimumLength(3);

        RuleFor(request => request.LastName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .MinimumLength(3);
        
        RuleFor(request => request.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
        
        RuleFor(request => request.Password)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .MinimumLength(5);
        
        RuleFor(request => request.FrontendTheme)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}