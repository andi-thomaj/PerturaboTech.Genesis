namespace PerturaboTech.Genesis.WebApi.Services.Abstractions.Infrastructure;

public interface ITokenProvider
{
    public string GenerateToken(string userId);
}