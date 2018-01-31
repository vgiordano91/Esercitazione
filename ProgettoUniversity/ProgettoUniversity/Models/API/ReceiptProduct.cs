using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{

    public class ReceiptProduct
    {
        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptProductCode")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptProductName")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ReceiptProductPrice")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", ConvertEmptyStringToNull = true)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "ReceiptProductQuantity")]
        [Range(0.1F, double.MaxValue)]
        public decimal Quantity { get; set; }

        public string Mode { get; set; }

        public string Family { get; set; }
    }
}

