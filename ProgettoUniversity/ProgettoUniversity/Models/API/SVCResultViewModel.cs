using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class SVCResultViewModel : ResultWithMessage
    {

        public SVCResultViewModel(string message, string status, int code) : base(message, status, code)
        {}

        public decimal CurrentBalance { get; set; }
        public string CurrentStatus { get; set; }
        public string ExpiryDate { get; set; }

        //public int ResultCode { get; set; }
        //public string ResultMessage { get; set; }
        //public string ResultStatus { get; set; }
        public string SerialNumber { get; set; }
        public string WebSerialNumber { get; set; }

        public int TransactionID {get;set;}

    }
}
