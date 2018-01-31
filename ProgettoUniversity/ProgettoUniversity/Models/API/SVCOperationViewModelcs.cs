using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class SVCOperationViewModel
    {
        public SVCOperationViewModel()
        {
            StoredValueCardCodeCollection = new List<string>();
            StoredValueCardReceipt = new ShopReceipt();
        }

        public IList<string> StoredValueCardCodeCollection { get; set; }
        public ShopReceipt StoredValueCardReceipt { get; set; }

    }
}
