﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name ="Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }

    }
}
