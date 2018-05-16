using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMiddleName { get; set; }

        [Display(Name = "Dated Hired")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMiddleName;
            }
        }

        public virtual ICollection<Course> Courses { get; set; }
        //public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}