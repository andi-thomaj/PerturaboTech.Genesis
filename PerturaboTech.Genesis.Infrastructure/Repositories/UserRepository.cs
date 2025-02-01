using PerturaboTech.Genesis.Domain.Entities;
using PerturaboTech.Genesis.Domain.Repositories;

namespace PerturaboTech.Genesis.Infrastructure.Repositories;

public class UserRepository(DapperContext dapperContext) : IUserRepository
{
    private readonly DapperContext _dapperContext = dapperContext;

    // public async Task<User> GetUserByIdAsync(Guid userId)
    // {
    //     var query = @"select * from Users where Id = @Id";
    //
    //     var connection = _dapperContext.CreateConnection();
    //     //await connection.Q
    //
    //     
    // }
}