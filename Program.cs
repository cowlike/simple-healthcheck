using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder();
builder.Services.AddHealthChecks()
    .AddCheck("Toggle Check", new ToggleCheck())
    .AddCheck("Another Check", () =>
    {
        Console.WriteLine("another check");
        return HealthCheckResult.Healthy("simple is good");
    });

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapHealthChecks("/health");
app.Run();

class ToggleCheck : IHealthCheck
{
    bool healthy = true;

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
    {
        Console.WriteLine("toggle check");
        healthy = !healthy;
        return Task.FromResult(healthy ? HealthCheckResult.Healthy("good") : HealthCheckResult.Unhealthy("bad"));
    }
}
