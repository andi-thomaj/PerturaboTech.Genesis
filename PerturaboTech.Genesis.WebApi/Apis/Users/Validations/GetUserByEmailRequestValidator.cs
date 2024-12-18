using FluentValidation;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Validations;

public class GetUserByEmailRequestValidator : AbstractValidator<GetUserByEmailRequest>
{
    public GetUserByEmailRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}