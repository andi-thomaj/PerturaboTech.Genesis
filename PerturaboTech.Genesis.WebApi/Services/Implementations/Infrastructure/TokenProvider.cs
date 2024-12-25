using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PerturaboTech.Genesis.WebApi.Data.Entities;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Infrastructure;

namespace PerturaboTech.Genesis.WebApi.Services.Implementations.Infrastructure;

 public class TokenProvider(IConfiguration configuration) : ITokenProvider
{
    public string GenerateToken(User user)
    {
        var secret = configuration["Jwt:Secret"];
        var key = Encoding.ASCII.GetBytes(secret!);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"]
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}