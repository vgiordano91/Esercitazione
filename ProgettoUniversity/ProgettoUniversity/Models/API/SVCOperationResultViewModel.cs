using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class SVCOperationResultViewModel : ResultWithMessage
    {

        public SVCOperationResultViewModel(string status, string message, int code) : base(status, message, code)
        {}

        //public string ResultStatus { get; set; }
        //public string ResultMessage { get; set; }
        //public int ResultCode { get; set; }

        public IList<ResultCollection> ResultCollection { get; set; }


    }
}
