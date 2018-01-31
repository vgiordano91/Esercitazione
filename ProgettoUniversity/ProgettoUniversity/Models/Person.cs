using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models
{
    public class Person
    {

        public int ID { get; set; }

        [Required]
        [Display(Name ="LastName Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [Display(Name="Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " , " + FirstMidName;
            }
        }


    }
}
