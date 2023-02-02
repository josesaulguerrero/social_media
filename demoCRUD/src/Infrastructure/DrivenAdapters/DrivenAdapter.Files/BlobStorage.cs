using Domain.Model.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Diagnostics.CodeAnalysis;

namespace DrivenAdapter.Files
{
    public class BlobStorage : IBlobStorage
    {
        private readonly CloudBlobContainer cloudBlobContainer;

        /// <summary>
        ///  BlobStorage
        /// </summary>
        [ExcludeFromCodeCoverage]
        public BlobStorage(string blobContainerName, string storageConnectionString)
        {
            //setea nombre completo de ruta contenedor
            string[] aux = blobContainerName.Split("/");
            //instancia de storage
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnectionString);
            //instancia de cliente storage
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            //obtiene instancia de contenedor del blob
            cloudBlobContainer = cloudBlobClient.GetContainerReference(aux[0]);
            //si contenedor no existe se crea
            cloudBlobContainer.CreateIfNotExistsAsync();
            //setea permisos contenedor a publico para prevenir conflictos en manejo
            BlobContainerPermissions permissions = cloudBlobContainer.GetPermissionsAsync().Result;
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            cloudBlobContainer.SetPermissionsAsync(permissions);
        }

        /// <summary>
        /// Validar URL storage asincronamente.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<bool> ValidarUrlStorageAsync(string path)
        {
            return await cloudBlobContainer.GetBlockBlobReference(path).ExistsAsync();
        }

        /// <summary>
        /// Obtener Archivo BlobStorage
        /// </summary>
        public async Task<string> ObtenerArchivo(string path)
        {
            return LeerArchivo(await DescargarArchivo(cloudBlobContainer.GetBlockBlobReference(path)));
        }

        /// <summary>
        /// Método que guarda copia de archivo en carpeta histórico
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        private static string LeerArchivo(byte[] archivo)
        {
            using StreamReader streamReader = new(new MemoryStream(archivo));
            return streamReader.ReadToEnd();
        }

        /// <summary>
        /// Método que guarda copia de archivo en carpeta histórico
        /// </summary>
        /// <param name="cloudBlockBlob"></param>
        /// <returns></returns>
        private static async Task<byte[]> DescargarArchivo(CloudBlockBlob cloudBlockBlob)
        {
            using MemoryStream memoryStream = new();
            await cloudBlockBlob.DownloadToStreamAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream.ToArray();
        }
    }
}