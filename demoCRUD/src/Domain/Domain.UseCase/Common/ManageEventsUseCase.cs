using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Domain.Model.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Domain.UseCase.Common
{
    /// <summary>
    /// Manage Events UseCase
    /// </summary>
    public class ManageEventsUseCase : IManageEventsUseCase
    {
        private readonly ITestEntityRepository testEntityRepository;
        private readonly ILogger<ManageEventsUseCase> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageEventsUseCase"/> class.
        /// </summary>
        /// <param name="testEntityRepository">The test entity repository.</param>
        /// <param name="logger">The logger.</param>
        public ManageEventsUseCase(ITestEntityRepository testEntityRepository, ILogger<ManageEventsUseCase> logger)
        {
            this.testEntityRepository = testEntityRepository;
            _logger = logger;
            _logger.LogInformation("Entro al use case en: {time}", DateTimeOffset.Now);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public List<Entity> FindAll(Entity entity = null)
        {
            return testEntityRepository.FindAll(entity);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public List<Entity> GetAllUsers(Entity entity = null)
        {
            return testEntityRepository.FindAll(entity);
        }

        /// <summary>
        /// <see cref="ConsoleProcessLog(string, string, dynamic, bool, string)"/>
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="writeData"></param>
        /// <param name="callerMemberName"></param>
        /// <returns></returns>
        public void ConsoleProcessLog(string eventName, string id, dynamic data, bool writeData = false, [CallerMemberName] string callerMemberName = null)
        {
            _logger.LogInformation($"ClassName: {eventName} - MethodName: {callerMemberName} - Id: {id}");

            if (writeData)
                _logger.LogInformation($"Data: {data}");
        }
    }
}