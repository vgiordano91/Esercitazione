using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class TransactionInfo
    {

        public int CardID { get; set; }

        public int TransactionID { get; set; }

        public decimal Value { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Notes { get; set; }

        public int TransactionStatus { get; set; }

        public int TransactionType { get; set; }

        public string AuthorizationCode { get; set; }

        public string Receipt { get; set; }

        public string Shop { get; set; }

        public string Terminal { get; set; }

        public ShopReceipt ConcreteReceipt { get; }

    }

}
