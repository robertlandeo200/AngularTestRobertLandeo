using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Models
{
    public class ResponseClient
    {
        public ClientCE oClient { get; set; }
        public List<ClientCE> ltClient { get; set; }
        public Response oReponse { get; set; }

        public ResponseClient()
        {
            oReponse = new Response();
        }
    }
}
