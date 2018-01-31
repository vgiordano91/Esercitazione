using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class AppliedDiscounts
    {
        public decimal TotalDiscount { get; set; }
        public decimal ShippingDiscount { get; set; }
        public string Partner { get; set; }
        public int PromotionMode { get; set; }
        
        public List<Details> Details { get; set; }

    }
}
