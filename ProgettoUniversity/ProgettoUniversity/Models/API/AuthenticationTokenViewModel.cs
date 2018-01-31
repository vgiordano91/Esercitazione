using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class AuthenticationTokenViewModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public double expires_in { get; set; }
        public string userName { get; set; }
    }
}
