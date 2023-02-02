namespace Helpers.ObjectsUtils.Setting
{
    /// <summary>
    /// Secrets
    /// </summary>
    public class Secrets
    {
        /// <summary>
        /// Retorna o asigna el/la sql connection.
        /// </summary>
        /// <value>Conexión a mongo.</value>
        public string MongoConnection { get; set; }

        /// <summary>
        /// Retorna o asigna la conexion al blobstorage
        /// </summary>
        public string StorageConnection { get; set; }

        /// <summary>
        /// Retorna o asigna la conexion a redis cache
        /// </summary>
        public string RedisConnection { get; set; }
    }
}