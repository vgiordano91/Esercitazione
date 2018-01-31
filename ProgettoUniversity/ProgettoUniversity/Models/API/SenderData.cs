using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class SenderData
    {
        public string Shop { get; set; }
        public string Terminal { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }
        public int CashDrawer { get; set; }
        public string Operator { get; set; }

    }
}
