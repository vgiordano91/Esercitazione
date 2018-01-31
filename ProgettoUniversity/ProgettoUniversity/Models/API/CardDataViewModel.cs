using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class CardDataViewModel
    {

        public string Password { get; set; }
        public string AuthorizationPin { get; set; }
        public string Approvals { get; set; }
        public string SecurityActivationToken { get; set; }
        public int NotificationType { get; set; }
        public CardholderViewModel Holder { get; set; }
        public PartnerDataViewModel Partnerships { get; set; }
        public MobileDeviceViewModel MobileDevices { get; set; }

    }
}
