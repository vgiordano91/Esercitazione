using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class CardholderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string FiscalCode { get; set; }
        public string VATCode { get; set; }
        public int Gender { get; set; }
        public CardholderAddressViewModel Address { get; set; }

    }
}
