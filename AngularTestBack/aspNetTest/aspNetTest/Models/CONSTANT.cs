using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Models
{
    public class CONSTANT
    {
        public const Int32 COMPLETO = 0;
        public const String COMPLETO_MSG = "La operación se completó con éxito";

        public const Int32 ERROR = -99;
        public const String ERROR_MSG = "No se pudo completar la operación. contáctese con el administrador del sistema.";

        public const Int32 SESSION = -2;
        public const String SESSION_ERROR_MSG = "Ha caducado el tiempo de sesión vuelva a iniciar sesión por favor.";

        public const Int32 SINPERMISOS = -1;
        public const String SINPERMISOS_ERROR_MSG = "USTED NO TIENE PERMISO PARA REALIZAR ESTA ACCIÓN EN ESTE FORMULARIO.";

        public const Int32 PERIOD_CLOSED = -3;
        public const String PERIOD_CLOSED_ERROR_MSG = "EL PERIODO CONTABLE SE ENCUENTRA CERRADO.";

        public const Int32 SIN_REGISTROS_INFO = -4;
        public const String SIN_REGISTROS_INFO_MSG = "NO SE ENCONTRO REGISTROS";

        public const Int32 ERROR_ACCESOSPAGINA = -5;
        public const String ERROR_MSG_ACCESOSPAGINA = "No tiene acceso a la pagina. contáctese con el administrador del sistema.";
    }
}
