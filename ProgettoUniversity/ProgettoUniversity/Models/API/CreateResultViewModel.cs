using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class CreateResultViewModel : ResultWithMessage
    {

        public CreateResultViewModel(string status, string message, int code) : base(status, message, code)
        {}

        public string SerialNumber { get; set; }
        public string WebSerialNumber { get; set; }
        public string IssueDate { get; set; }
        public int TransactionID { get; set; }
        //public string ResultStatus { get;set;}
        //public string ResultMessage { get;set;}
        //public int ResultCode { get;set;}

    }
}
