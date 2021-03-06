﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace ContosoUniversity.Core.Domain
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public string FullName
        {
            get

            {
                return FirstName + " " + MiddleName + " " +LastName;
            }
        }

        public ICollection<Course> Courses { get; set; }
    }
}