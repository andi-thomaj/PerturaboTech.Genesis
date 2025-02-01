namespace PerturaboTech.Genesis.Shared.Configurations;

public class JwtSettings
{
    internal const string SectionName = nameof(JwtSettings);
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; }
}