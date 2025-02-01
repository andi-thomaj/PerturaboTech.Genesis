using MediatR;
using PerturaboTech.Genesis.Domain.Repositories;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Queries;

public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUser.Query, GetUser.Result>
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<GetUser.Result> Handle(GetUser.Query request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}