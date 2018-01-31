using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class Issuer
    {
        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptIssuerName")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptIssuerAddress")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptIssuerTelephone")]
        [RegularExpression(@"\(?([0-9]{7,10})")]
        public string Telephone { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptIssuerMail")]
        [EmailAddress]
        public string EMail { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "ReceiptIssuerVatNumber")]
        public string VATNumber { get; set; }
    }
}
