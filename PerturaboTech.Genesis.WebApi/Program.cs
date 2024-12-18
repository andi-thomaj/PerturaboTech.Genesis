using Microsoft.EntityFrameworkCore;
using PerturaboTech.Genesis.WebApi.Apis.Users;
using PerturaboTech.Genesis.WebApi.Data;
using PerturaboTech.Genesis.WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
var connectionString = configuration.GetConnectionString("DefaultConnection");
Ensure.NotNullOrEmpty(connectionString);
services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
        
app.MapUsersEndpoints();
app.Run();