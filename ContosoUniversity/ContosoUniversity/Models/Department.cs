using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }

        [Display(Name = "Date Started")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

    
        public int? InstructorId { get; set; }
        public virtual ICollection<Instructor> Administrator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}