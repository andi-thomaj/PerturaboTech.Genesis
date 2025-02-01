using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using PerturaboTech.Genesis.Shared.Configurations;
using PerturaboTech.Genesis.WebApi;
using Testcontainers.PostgreSql;

namespace PerturaboTech.Genesis.Test.IntegrationTests;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("development_genesis")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.Configure<DatabaseOptions>(options =>
            {
                options.ConnectionString = _dbContainer.GetConnectionString();
            });
        });
    }

    public Task InitializeAsync() => _dbContainer.StartAsync();
    public new Task DisposeAsync() => _dbContainer.StopAsync();
}