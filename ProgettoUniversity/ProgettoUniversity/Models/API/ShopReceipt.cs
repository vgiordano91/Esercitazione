using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class ShopReceipt
    {
        public ShopReceipt()
        {
            this.Products = new List<ReceiptProduct>();
            this.Payments = new List<Payment>();
            this.IssuerData = new Issuer();
            this.SenderData = new SenderData();
        }

        [Required]
        [Display(Name = "IssuerData")]
        public Issuer IssuerData { get; set; }

        [Required]
        [Display(Name = "IssueDate")]
        public DateTime IssueDate { get; set; }

        [Required]
        [Display(Name = "Products")]
        public List<ReceiptProduct> Products { get; set; }

        [Required]
        [Display(Name = "Payments")]
        public List<Payment> Payments { get; set; }

        [Required]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "SenderData")]
        public SenderData SenderData { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "UserData")]
        [StringLength(4096, MinimumLength = 0)]
        public string UserData { get; set; }

        //IssueDateDayOfWeek
        //public int IssueDateDayOfWeek
        //{
        //    get
        //    {
        //        return (int)IssueDate.DayOfWeek;
        //    }
        //}

        //public TimeSpan IssueDateTimeOfDay
        //{
        //    get
        //    {
        //        return IssueDate.TimeOfDay;
        //    }
        //}

    }
}
