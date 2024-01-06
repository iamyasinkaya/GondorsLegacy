namespace GondorsLegacy.Infrastructure.Monitoring.OpenTelemetry;

public class OpenTelemetryOptions
{
    public string ServiceName { get; set; } = null!;
    public string ServiceVersion { get; set; } = null!;
    public string ActivitySourceName { get; set; } = null!;
}
