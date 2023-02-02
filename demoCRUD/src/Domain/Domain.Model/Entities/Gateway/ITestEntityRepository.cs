using System.Collections.Generic;

namespace Domain.Model.Entities.Gateway
{
    /// <summary>
    /// ITestEntityRepository
    /// </summary>
    public interface ITestEntityRepository
    {
        /// <summary>
        /// FindAll
        /// </summary>
        /// <returns>Entity list</returns>
        List<Entity> FindAll(Entity entity = null);
    }
}