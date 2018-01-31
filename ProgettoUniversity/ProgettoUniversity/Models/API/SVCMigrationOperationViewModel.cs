using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class SVCMigrationOperationViewModel
    {

        public string StoredValueCardCode { get; set; }
        public ShopReceipt StoredValueCardReceipt { get; set; }
        public string OldCardCode { get; set; }
        public string Notes { get; set; }

    }
}
