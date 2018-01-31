using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class Payment
    {

        public Payment()
        {
            Method = PaymentMethod.Cash;
            Amount = 0;
        }

        [Required]
        [Display(Name = "Method")]
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod Method { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "CardCode")]
        public string CardCode { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
    }
}
