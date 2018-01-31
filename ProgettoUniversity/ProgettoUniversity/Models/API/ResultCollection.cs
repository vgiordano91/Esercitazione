using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class ResultCollection
    {

        public decimal CurrentBalance { get; set; }
        public string CurrentStatus { get; set; }
        public string SerialNumber { get; set; }
        public int TransactionID { get; set; }

        public AppliedDiscounts AppliedDiscounts { get; set; }

    }
}
