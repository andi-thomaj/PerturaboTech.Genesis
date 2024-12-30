using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Apis.Users.Responses;

public record LoginWithEmailAndPasswordResponse(string AccessToken, string RefreshToken);