using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace demoCRUD.AppServices.Extensions.Health
{
    /// <summary>
    /// HealthCheckExtensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class HealthCheckExtensions
    {
        /// <summary>
        ///   Services the health checks.
        /// </summary>
        /// <param name="app">application.</param>
        /// <param name="endpoint">endpoint.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns></returns>
        public static IApplicationBuilder ServiceHealthChecks(this IApplicationBuilder app, string endpoint, string serviceName)
        {
            return app.UseHealthChecks(endpoint, new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = async (context, report) =>
                {
                    string result = JsonSerializer.Serialize(
                    new HealthResult
                    {
                        ServiceName = serviceName,
                        Status = report.Status.ToString(),
                        Duration = report.TotalDuration,
                        Checks = report.Entries.Select(e => new HealthInfo
                        {
                            Name = e.Key,
                            Description = e.Value.Description,
                            Duration = e.Value.Duration,
                            Status = Enum.GetName(typeof(HealthStatus),
                                                    e.Value.Status),
                            Error = e.Value.Exception?.Message
                        }).ToList()
                    },
                    new JsonSerializerOptions
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        WriteIndented = false
                    });

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });
        }
    }
}