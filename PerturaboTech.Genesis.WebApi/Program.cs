using Microsoft.EntityFrameworkCore;
using PerturaboTech.Genesis.WebApi.Apis.Users;
using PerturaboTech.Genesis.WebApi.Data;
using PerturaboTech.Genesis.WebApi.Helpers;
using PerturaboTech.Genesis.WebApi.Services.Abstractions;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Repository;
using PerturaboTech.Genesis.WebApi.Services.Implementations;
using PerturaboTech.Genesis.WebApi.Services.Implementations.Repository;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
var connectionString = configuration.GetConnectionString("DefaultConnection");
Ensure.NotNullOrEmpty(connectionString);
services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IUserService, UserService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();
services.AddAuthentication();
services.AddAuthorization();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
        
app.MapUsersEndpoints();

app.Run();