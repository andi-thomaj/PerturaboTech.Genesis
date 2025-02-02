using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Services.Abstractions.Infrastructure;

public interface ITokenProvider
{
    public string GenerateToken(User user);
    string GenerateRefreshToken();
}