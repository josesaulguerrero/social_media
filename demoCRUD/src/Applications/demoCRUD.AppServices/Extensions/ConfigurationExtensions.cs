using Helpers.ObjectsUtils.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using SC.Configuration.Provider.Mongo;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace demoCRUD.AppServices.Extensions
{
    /// <summary>
    /// ConfigurationExtensions
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ConfigurationExtensions
    {
        /// <summary>
        ///   Agrega archivo JSON como proveedor de configuración.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddJsonProvider(this IConfigurationBuilder configuration)
                => configuration
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("config/appsettings.json", optional: true, reloadOnChange: true);

        /// <summary>
        /// Adds the key vault provider.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IConfigurationBuilder AddKeyVaultProvider(this ConfigurationManager configuration)
        {
            AzureKeyVaultConfig settings = new();
            configuration.GetSection(nameof(AzureKeyVaultConfig)).Bind(settings);
            configuration.AddAzureKeyVault(new AzureKeyVaultConfigurationOptions(settings.KeyVault, settings.AppId, settings.AppSecret));
            return configuration;
        }

        /// <summary>
        ///   Agrega Mongo como proveedor de configuración.
        /// </summary>
        /// <param name="configuration">configuration.</param>
        /// <param name="sectionName">Name of the configuration section.</param>
        /// <param name="connectionString">data base connection string.</param>
        /// <param name="suffix">suffix.</param>
        /// <returns></returns>
        public static IConfigurationBuilder AddMongoProvider(this ConfigurationManager configuration,
               string sectionName, string connectionString, string suffix)
        {
            MongoAppsettingsConfiguration settings = new MongoAppsettingsConfiguration();
            configuration.GetSection(sectionName).Bind(settings);
            settings.ConnectionString = connectionString;
            configuration.AddMongoConfiguration(options =>
            {
                options.ConnectionString = settings.ConnectionString;
                options.CollectionName = settings.CollectionName;
                options.DatabaseName = $"{settings.DatabaseName}_{suffix}";
                options.ReloadOnChange = settings.ReloadOnChange;
            });

            return configuration;
        }

        /// <summary>
        ///   Resuelve los secretKey de la sección secretos con los valores configurados en el keyVault
        ///   Provider de Azure.
        /// </summary>
        /// <param name="configuration"></param>
        public static T ResolveSecrets<T>(this IConfiguration configuration)
        {
            IConfigurationSection secretsSection = configuration.GetRequiredSection(typeof(T).Name);

            foreach (KeyValuePair<string, string> secret in secretsSection.AsEnumerable().Skip(1))
            {
                string secretValue = configuration.GetValue<string>(secret.Value);

                if (secretValue is null) continue;

                configuration[secret.Key] = secretValue;
            }

            return secretsSection.Get<T>();
        }
    }
}