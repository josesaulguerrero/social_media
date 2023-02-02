using System.ComponentModel;

namespace Helpers.Commons.Exceptions
{
    /// <summary>
    /// ResponseError
    /// </summary>
    public enum TipoExcepcionNegocio
    {
        /// <summary>
        /// Tipo de exception no controlada
        /// </summary>
        [Description("Excepción de negocio no controlada")]
        ExceptionNoControlada = 555,

        /// <summary>
        /// El tipo de contrato especificado no existe.
        /// </summary>
        [Description("El tipo de contrato especificado no existe.")]
        ErrorNoExisteTipoContrato = 556,

        /// <summary>
        /// El tipo de contrato especificado ya existe
        /// </summary>
        [Description("El tipo de contrato especificado ya existe")]
        ErrorExisteTipoContrato = 557,

        /// <summary>
        /// ¡El esquema del tipo de contrato no existe!
        /// </summary>
        [Description("¡El esquema del tipo de contrato no existe!")]
        ErrorNoExisteExquemaTipoContrato = 558,

        /// <summary>
        /// ¡El archivo de la vigencia no existe!
        /// </summary>
        [Description("¡El archivo de la vigencia no existe!")]
        ErrorNoExisteArchivoVigencia = 559,

        /// <summary>
        /// Error no controlado al insertar un tipo de contrato
        /// </summary>
        [Description("Error no controlado al insertar un tipo de contrato")]
        ErrorAlInsertarTipoContrato = 560,

        /// <summary>
        /// Error no controlado al insertar una vigencia
        /// </summary>
        [Description("Error no controlado al insertar una vigencia")]
        ErrorAlInsertarVigencia = 561,

        /// <summary>
        /// Excepción al intentar obtener datos de mongo
        /// </summary>
        [Description("Excepción al intentar obtener datos de mongo")]
        ExceptionAlIntentarObtenerDatosDeMongo = 562,

        /// <summary>
        /// No se cumple con el esquema definido para la colección Tipos Contrato
        /// </summary>
        [Description("No se cumple con el esquema definido para la colección Tipos Contrato")]
        ErrorAlCrearTipoContratoNoCumpleEsquema = 563,

        /// <summary>
        /// No se puede crear una vigencia con una fecha/hora anterior a la actual
        /// </summary>
        [Description("No se puede crear una vigencia con una fecha/hora anterior a la actual")]
        ErrorAlCrearVigenciaConFechaAnteriorAlaActual = 564,

        /// <summary>
        /// No se puede modificar una vigencia con una fecha/hora anterior a la actual
        /// </summary>
        [Description("No se puede modificar la vigencia {0} ya que tiene una fecha/hora anterior a la actual")]
        ErrorAlModificarVigenciaConFechaAnteriorAlaActual = 565,

        /// <summary>
        /// No existen registros en mongo, para recargar
        /// </summary>
        [Description("No existen registros en mongo, para recargar.")]
        ErrorNoSeEncontroTiposContrato = 566,

        /// <summary>
        /// No se cumple con el esquema definido para la colección de Vigencias
        /// </summary>
        [Description("No se cumple con el esquema definido para la colección Vigencias")]
        ErrorAlCrearTipoContratoVigenciaNoCumpleEsquema = 567,

        /// <summary>
        /// El nombre del Core no existe, por favor registrelo
        /// </summary>
        [Description("El nombre del Core no existe, por favor registrelo")]
        ErrorNoExisteCoreTipoContrato = 568,

        /// <summary>
        /// No se puede modificar una vigencia con una fecha/hora anterior a la actual
        /// </summary>
        [Description("No se puede modificar la vigencia porque tiene una fecha/hora anterior a la actual")]
        ErrorAlModificarLaVigenciaConFechaAnteriorAlaActual = 569,

        /// <summary>
        /// El tipo de contrato especificado ya existe
        /// </summary>
        [Description("El nombre del core especificado ya existe")]
        ErrorExisteCoreTipoContrato = 570,

        /// <summary>
        /// El tipo de contrato especificado no existe.
        /// </summary>
        [Description("El nombre del core especificado no existe.")]
        ErrorNoExisteCore = 571,

        /// <summary>
        /// El historico de tipo de contrato no existe.
        /// </summary>
        [Description("El historico de tipo de contrato no existe.")]
        ErrorNoExisteHistoricoTipoContrato = 572,

        /// <summary>
        /// falta una vigencia antigua en request
        /// </summary>
        [Description("falta una vigencia antigua en request.")]
        FaltaUnaVigenciaAntiguaEnRequest = 573,

        /// <summary>
        /// se cambio informacion de una vigencia antigua
        /// </summary>
        [Description("no se puede cambiar la información de una vigencia antigua y ya existente.")]
        ErrorSeCambioInformacionDeUnaVigenciaAntigua = 574,

        /// <summary>
        /// el hash de una vigencia no coincide
        /// </summary>
        [Description("el hash de una vigencia no coincide.")]
        ElHashDeUnaVigenciaNoCoincide = 575
    }
}