﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Web.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMiddleName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstMiddleName + "  " + LastName; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }

        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthday;
                var years = timeSpan.Days / 365;
                return years;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}