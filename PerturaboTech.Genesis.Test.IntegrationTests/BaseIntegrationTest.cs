using Microsoft.Extensions.DependencyInjection;
using PerturaboTech.Genesis.WebApi.Data;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Repositories;

namespace PerturaboTech.Genesis.Test.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    private readonly IUserRepository _userRepository;
    private readonly DapperContext _dapperContext;

    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        
        _userRepository = _scope.ServiceProvider.GetRequiredService<IUserRepository>();
        _dapperContext = _scope.ServiceProvider.GetRequiredService<DapperContext>();
    }
}