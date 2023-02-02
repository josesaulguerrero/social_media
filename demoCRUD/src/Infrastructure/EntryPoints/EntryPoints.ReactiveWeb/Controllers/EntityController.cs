using Domain.Model.Entities;
using Domain.Model.Interfaces;
using EntryPoints.ReactiveWeb.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;

namespace EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// EntityController
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class EntityController : AppControllerBase<EntityController>
    {
        private readonly IManageEventsUseCase testNegocio;
        private readonly ILogger<EntityController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityController"/> class.
        /// </summary>
        /// <param name="testNegocio">The test negocio.</param>
        /// <param name="logger">The logger.</param>
        public EntityController(IManageEventsUseCase testNegocio, ILogger<EntityController> logger) :
            base(testNegocio)
        {
            _logger = logger;
            this.testNegocio = testNegocio;
        }

        /// <summary>
        /// Obtiene todos los objetos de tipo <see cref="Entity"/>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna la lista</response>
        /// <response code="400">Si existe algun problema al consultar</response>
        /// <response code="406">Si no se envia el ambiente correcto</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Entro al controlador en: {time}", DateTimeOffset.Now);
            var respuestaNegocio = testNegocio.GetAllUsers();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> Create([FromBody] Entity entity)
        {
            var respuestaNegocio = testNegocio.GetAllUsers(entity);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
    }
}