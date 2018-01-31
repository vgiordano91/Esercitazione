using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class CardDetailViewModel : ResultWithMessage
    {
        public CardDetailViewModel()
        {
            this.Transactions = new List<TransactionInfo>();
        }

        public CardDetailViewModel(string status, string message, int code) : base(status, message, code)
        {
            this.Transactions = new List<TransactionInfo>();
        }

        public string SerialNumber { get; set; }

        public string WebSerialNumber { get; set; }

        public string CampaignCardLogo { get; set; }

        public string CurrentStatus { get; set; }

        public DateTime ExpiryDate { get; set; }

        //public IBalanceResult Balance { get; set; }
        public decimal CurrentBalance { get; set; }

        public IList<TransactionInfo> Transactions { get; set; }

    }
}
