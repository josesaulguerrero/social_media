using credinet.comun.api;
using credinet.exception.middleware.models;
using Domain.Model.Interfaces;
using Helpers.Commons.Exceptions;
using Helpers.ObjectsUtils.Extensions;
using Helpers.ObjectsUtils.ResponseObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;

namespace EntryPoints.ReactiveWeb.Base
{
    /// <summary>
    /// AppControllerBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BaseController&lt;T&gt;" />
    public class AppControllerBase<T> : BaseController<T>
    {
        private readonly string country = "co";

        private readonly IManageEventsUseCase _eventsService;

        /// <summary>
        /// Creates new instance of <see cref="AppControllerBase{T}"/>
        /// </summary>
        /// <param name="eventsService"></param>
        public AppControllerBase(IManageEventsUseCase eventsService)
        {
            _eventsService = eventsService;
        }

        /// <summary>
        /// Handles a controller request.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestHandler"></param>
        /// <param name="logId"></param>
        /// <returns></returns>
        public async Task<IActionResult> HandleRequest<TResult>(Func<Task<TResult>> requestHandler, string logId)
        {
            string actionName = ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            string eventName = $"{controllerName}.{actionName}";

            _eventsService.ConsoleProcessLog(eventName, logId, data: null);

            try
            {
                TResult result = await requestHandler();
                return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", country, result)));
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.StackTrace);
                return BadRequest(new ResponseError(new List<ResponseContent> {
                    new ResponseContent(ex.Message, $"{(TipoExcepcionNegocio.ExceptionNoControlada.GetDescription(), (int)TipoExcepcionNegocio.ExceptionNoControlada)} - {ex.Message}")
                }));
            }
        }
    }
}