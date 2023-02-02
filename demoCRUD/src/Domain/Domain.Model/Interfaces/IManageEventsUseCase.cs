using Domain.Model.Entities;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Domain.Model.Interfaces
{
    /// <summary>
    /// IManageEventsUseCase
    /// </summary>
    public interface IManageEventsUseCase
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        List<Entity> GetAllUsers(Entity entity = null);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        List<Entity> FindAll(Entity entity = null);

        /// <summary>
        /// Consoles the process log.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="data">The data.</param>
        /// <param name="writeData">if set to <c>true</c> [write data].</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        void ConsoleProcessLog(string eventName, string id, dynamic data, bool writeData = false, [CallerMemberName] string callerMemberName = null);
    }
}