using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Models
{
    public class Instructor : Person
    {

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy:MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Department> Departments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }


    }
}
