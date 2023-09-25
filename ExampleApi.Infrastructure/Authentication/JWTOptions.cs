namespace ExampleApi.Infrastructure.Authentication;

public class JWTOptions
{
    public const string SettingsName = "JWTOptions";

    public string? Secret { get; init; }

    public string? Issuer { get; init; }

    public int ExpiryMinutes { get; init; }
}
