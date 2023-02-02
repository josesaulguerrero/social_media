using System.Threading.Tasks;

namespace Domain.Model.Interfaces
{
    /// <summary>
    /// The blob store repository contract.
    /// </summary>
    public interface IBlobStorage
    {
        /// <summary>
        /// Validar URL storage asincronamente.
        /// </summary>
        /// <param name="path">el path.</param>
        /// <returns></returns>
        Task<bool> ValidarUrlStorageAsync(string path);

        /// <summary>
        /// Obtiene el archivo asincronamente
        /// </summary>
        /// <param name="path">el path.</param>
        /// <returns></returns>
        Task<string> ObtenerArchivo(string path);
    }
}