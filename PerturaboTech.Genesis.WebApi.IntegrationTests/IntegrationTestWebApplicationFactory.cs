using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerturaboTech.Genesis.WebApi;
using PerturaboTech.Genesis.WebApi.Data;
using Testcontainers.PostgreSql;

namespace Perturabo.Genesis.WebApi.IntegrationTests;

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
            var dbContextDescriptor = services
                .SingleOrDefault(x => x.ServiceType == typeof(ApplicationDbContext));

            if (dbContextDescriptor is not null)
            {
                services.Remove(dbContextDescriptor);
            }

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
        });
    }

    public Task InitializeAsync() => _dbContainer.StartAsync();

    public new Task DisposeAsync() => _dbContainer.StopAsync();
}