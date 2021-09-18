using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Models
{
    public class Response
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }

        public Response()
        {
            this.responseCode = CONSTANT.COMPLETO;
            this.responseMessage = CONSTANT.COMPLETO_MSG;
        }

        public void setResponseSuccessfully()
        {
            this.responseCode = CONSTANT.COMPLETO;
            this.responseMessage = CONSTANT.COMPLETO_MSG;
        }

        public void setResponseError()
        {
            this.responseCode = CONSTANT.ERROR;
            this.responseMessage = CONSTANT.ERROR_MSG;
        }
        public void setResponseSinRegistros()
        {
            this.responseCode = CONSTANT.SIN_REGISTROS_INFO;
            this.responseMessage = CONSTANT.SIN_REGISTROS_INFO_MSG;
        }
    }
}
