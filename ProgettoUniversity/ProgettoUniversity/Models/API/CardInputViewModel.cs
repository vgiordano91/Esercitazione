using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class CardInputViewModel
    {
        //[Required]
        [StringLength(34, MinimumLength = 34)]
        public string CardCode { get; set; }

        public int TypeOperation { get; set; }

    }
}
