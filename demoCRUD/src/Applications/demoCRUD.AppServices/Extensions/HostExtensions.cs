using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace demoCRUD.AppServices.Extensions
{
    /// <summary>
    /// Host Extensions
    /// </summary>
    public static class HostExtensions
    {
        /// <summary>
        /// Configura Serilog
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder) =>
            hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                        .ReadFrom.Configuration(context.Configuration)
                        .WriteTo.Elasticsearch(
                        new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(context.Configuration["Serilog:ElasticsearchUrl"]))
                        {
                            AutoRegisterTemplate = true,
                            AutoRegisterTemplateVersion = Serilog.Sinks.Elasticsearch.AutoRegisterTemplateVersion.ESv7,
                            IndexFormat = context.Configuration["Serilog:IndexFormat"]
                        })
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .Enrich.WithProperty("ApplicationName", context.HostingEnvironment.ApplicationName)
                        .Enrich.FromLogContext();
            });
    }
}