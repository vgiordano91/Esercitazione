using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models.API
{
    public class AssociateOperationViewModel
    {
        [Required]
        [StringLength(34, MinimumLength = 34 )]
        public string Card { get; set; }
        [Required]
        public string Shop { get; set; }
        [Required]
        public string Terminal { get; set; }
        [Required]
        public CardDataViewModel CardData { get; set; }

        public string Notes { get; set; }

    }
}
