namespace PerturaboTech.Genesis.WebApi.Data.Repositories;

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