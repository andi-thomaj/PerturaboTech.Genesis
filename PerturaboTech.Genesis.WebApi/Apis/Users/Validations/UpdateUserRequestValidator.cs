using FluentValidation;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Validations;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
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
        
        RuleFor(request => request.FrontendTheme)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}