namespace PerturaboTech.Genesis.WebApi.Apis.Users.Responses;

public record LoginWithRefreshTokenResponse(string AccessToken, string RefreshToken);