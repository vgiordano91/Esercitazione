using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity
{
    public class Constants
    {
        //public const string BASE_ADDRESS = @"https://api.domec.lab";
        public const string BASE_ADDRESS = @"https://localhost:44302";
        public const string DOMEC_API_USERNAME = "admin@domecsolutions.com";
        public const string DOMEC_API_PASSWORD = "pr@D2015:cecdsmpss";
        //public const string SHOP = "DOMECGO";
        //public const string TERMINAL = "DOMECGO_TERM";
        public const string SHOP = "CR1";
        public const string TERMINAL = "CRDGI1";

        public const string API_TOKEN = "/token";

        public const string API_STATUS = "svc/status";
        public const string API_TRANSACTIONS = "svc/transactions";
        public const string API_BALANCE = "svc/balance";
        public const string API_CHARGE = "svc/charge";
        public const string API_CREATE = "svc/create";
        public const string API_ACTIVATE = "svc/activate";
        public const string API_MIGRATE = " svc/migrate";

        public const int MSG_RESULT_CODE_OK = 0000;
        public const int MSG_RESULT_CODE_KO = 9999;
        public const string MSG_RESULT_STATUS_OK = "OK";
        public const string MSG_RESULT_STATUS_NOK = "KO";
        public const string MSG_RESULT_MESSAGE_OK = "Operation completed successfully";
    }
}
