using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Models
{
    public class ResponseLoans
    {
        public LoansCE oLoans { get; set; }
        public List<LoansCE> ltLoans { get; set; }
        public Response oReponse { get; set; }

        public ResponseLoans()
        {
            oReponse = new Response();
        }
    }
}
