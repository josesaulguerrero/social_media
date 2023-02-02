using System;
using System.Collections.Generic;

namespace demoCRUD.AppServices.Extensions.Health
{
    /// <summary>
    /// Health result
    /// </summary>
    public class HealthResult
    {
        /// <summary>
        ///   Retorna o asigna el/la name.
        /// </summary>
        /// <value>name.</value>
        public string ServiceName { get; set; }

        /// <summary>
        ///   Retorna o asigna el/la status.
        /// </summary>
        /// <value>status.</value>
        public string Status { get; set; }

        /// <summary>
        ///   Retorna o asigna el/la duration.
        /// </summary>
        /// <value>duration.</value>
        public TimeSpan Duration { get; set; }

        /// <summary>
        ///   Retorna o asigna el/la information.
        /// </summary>
        /// <value>information.</value>
        public ICollection<HealthInfo> Checks { get; set; }
    }
}