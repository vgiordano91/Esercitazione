using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class MobileDeviceViewModel
    {
        public string Token { get; set; }
        public string Os { get; set; }
        public string DeviceIdiom { get; set; }
        public string DeviceUniqueID { get; set; }

    }
}
