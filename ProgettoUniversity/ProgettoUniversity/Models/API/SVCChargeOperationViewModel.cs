using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class SVCChargeOperationViewModel
    {
        public SVCChargeOperationViewModel()
        {
            StoredValueCardCodeCollection = new List<string>();
            StoredValueCardReceipt = new ShopReceipt();
        }
        public SVCCashbackType CashbackType { get; set; }
        public IList<string> StoredValueCardCodeCollection { get; set; }
        public ShopReceipt StoredValueCardReceipt { get; set; }
        public string Notes { get; set; }

    }
}
