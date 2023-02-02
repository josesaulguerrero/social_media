using AutoMapper;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DrivenAdapters.Mongo.Entities
{
    /// <summary>
    /// EntityAdapter
    /// </summary>
    public class EntityAdapter : ITestEntityRepository
    {
        private readonly IMapper mapper;
        private readonly ILogger<EntityAdapter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAdapter"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public EntityAdapter(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAdapter"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public EntityAdapter(IMapper mapper, ILogger<EntityAdapter> logger)
        {
            _logger = logger;
            this.mapper = mapper;
        }

        /// <summary>
        /// FindAll
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Entity list
        /// </returns>
        public List<Domain.Model.Entities.Entity> FindAll(Domain.Model.Entities.Entity entity = null)
        {
            _logger.LogInformation("Entro al adapter en: {time}", DateTimeOffset.Now);
            if (entity == null)
            {
                try
                {
                    return mapper.Map<List<Domain.Model.Entities.Entity>>(new List<Domain.Model.Entities.Entity> { new Domain.Model.Entities.Entity { Id = Guid.NewGuid(), descrip = "Test" } });
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return mapper.Map<List<Domain.Model.Entities.Entity>>(new List<Domain.Model.Entities.Entity> { new Domain.Model.Entities.Entity { Id = entity.Id, descrip = entity.descrip } });
        }
    }
}