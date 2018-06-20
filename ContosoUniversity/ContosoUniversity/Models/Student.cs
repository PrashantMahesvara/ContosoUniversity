using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMiddleName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstMiddleName + ", " + LastName; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string SSN { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}