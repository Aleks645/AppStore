using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Linq;

namespace AppStore.HealthChecks
{
    public static class HealthCheck
    {
        public static void ConfigureHealthCheckEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    var json = JsonSerializer.Serialize(new
                    {
                        status = report.Status.ToString(),
                        checks = report.Entries.Select(e => new { key = e.Key, value = e.Value.Status.ToString() }),
                        duration = report.TotalDuration.TotalMilliseconds
                    });
                    await context.Response.WriteAsync(json);
                }
            });
        }
    }
}
