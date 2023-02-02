using System;

namespace demoCRUD.AppServices.Extensions.Health
{
    /// <summary>
    /// HealthInfo
    /// </summary>
    public class HealthInfo
    {
        /// <summary>
        /// Retorna o asigna el nombre del health
        /// </summary>
        /// <value>key.</value>
        public string? Name { get; set; }

        /// <summary>
        /// Retorna o asigna el/la descripción
        /// </summary>
        /// <value>description.</value>
        public string? Description { get; set; }

        /// <summary>
        /// Retorna o asigna la duración
        /// </summary>
        /// <value>duration.</value>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Retorna o asigna el estado
        /// </summary>
        /// <value>status.</value>
        public string? Status { get; set; }

        /// <summary>
        /// Retorna o asigna el error.
        /// </summary>
        /// <value>error.</value>
        public string? Error { get; set; }
    }
}