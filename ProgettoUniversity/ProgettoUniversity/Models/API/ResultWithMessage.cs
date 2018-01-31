using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class ResultWithMessage
    {
        public ResultWithMessage()
        {
            //Questo costruttore ritorna un oggetto con risultato positivo

            this.ResultStatus = Constants.MSG_RESULT_STATUS_OK;
            this.ResultMessage = Constants.MSG_RESULT_MESSAGE_OK;
            this.ResultCode = Constants.MSG_RESULT_CODE_OK;
        }

        public ResultWithMessage(string status, string message, int code)
        {
            this.ResultStatus = status;
            this.ResultMessage = message;
            this.ResultCode = code;
        }

        public string ResultStatus { get; set; }

        public string ResultMessage { get; set; }

        public int ResultCode { get; set; }
    }
}
