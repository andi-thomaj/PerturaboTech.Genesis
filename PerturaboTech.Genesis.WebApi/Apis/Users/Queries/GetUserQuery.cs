using MediatR;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Queries;

public class GetUser
{
    public class Query : IRequest<Result>
    {
        public Guid UserId { get; set; }
    }
    public class Result
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}