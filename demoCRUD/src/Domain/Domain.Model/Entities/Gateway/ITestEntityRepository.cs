using System.Collections.Generic;

namespace Domain.Model.Entities.Gateway
{
    /// <summary>
    /// ITestEntityRepository
    /// </summary>
    public interface ITestEntityRepository
    {
        /// <summary>
        /// FindAllAsync
        /// </summary>
        /// <returns>Entity list</returns>
        List<Entity> FindAll(Entity entity = null);
    }
}