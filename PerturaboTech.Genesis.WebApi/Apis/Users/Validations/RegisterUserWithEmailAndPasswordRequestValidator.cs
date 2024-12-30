using FluentValidation;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Validations;

public class RegisterUserWithEmailAndPasswordRequestValidator : AbstractValidator<RegisterUserWithEmailAndPasswordRequest>
{
    public RegisterUserWithEmailAndPasswordRequestValidator()
    {
        RuleFor(request => request.FirstName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .MinimumLength(3);
        
        RuleFor(request => request.MiddleName)
            .MaximumLength(50)
            .MinimumLength(3);

        RuleFor(request => request.LastName)
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
    }
}