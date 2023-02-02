namespace Helpers.ObjectsUtils.Setting
{
    /// <summary>
    /// Configuration properties for azure key vault service
    /// </summary>
    public class AzureKeyVaultConfig
    {
        /// <summary>
        ///   Retorna o asigna el/la tenant Id.
        /// </summary>
        /// <value>Tenant Id.</value>
        public string TenantId { get; set; }

        /// <summary>
        ///   Retorna o asigna el/la key vault.
        /// </summary>
        /// <value>Key vault.</value>
        public string KeyVault { get; set; }

        /// <summary>
        ///   Retorna o asigna el/la application Id.
        /// </summary>
        /// <value>Application Id.</value>
        public string AppId { get; set; }

        /// <summary>
        ///   Retorna o asigna el/la application secret.
        /// </summary>
        /// <value>Application secret.</value>
        public string AppSecret { get; set; }
    }
}