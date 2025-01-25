namespace GondorsLegacy.Services.External;

public class LodgifyApiSettings
{
    public required string BaseUrl { get; init; }
    public required string ApiKey { get; init; }
    public required string AcceptHeader { get; init; }
}
