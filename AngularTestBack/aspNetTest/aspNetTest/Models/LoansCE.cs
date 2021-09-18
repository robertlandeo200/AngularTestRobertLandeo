using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetTest.Models
{
    public class LoansCE
    {
        public int ID_Request_Loans { get; set; }
        public int ID_Client { get; set; }
        public string T_ClientName { get; set; }
        public string D_Date_Request { get; set; }
        public decimal N_Request_Amount { get; set; }
    }
}
