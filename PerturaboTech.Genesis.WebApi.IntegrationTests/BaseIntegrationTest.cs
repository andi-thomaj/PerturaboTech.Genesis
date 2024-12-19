using Microsoft.Extensions.DependencyInjection;
using PerturaboTech.Genesis.WebApi.Data;
using PerturaboTech.Genesis.WebApi.Services.Abstractions;

namespace Perturabo.Genesis.WebApi.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    protected readonly IUserService _userService;
    protected readonly ApplicationDbContext _dbContext;

    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();

        _userService = _scope.ServiceProvider.GetRequiredService<IUserService>();
        _dbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}