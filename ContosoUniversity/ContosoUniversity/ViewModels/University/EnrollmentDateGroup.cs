using System.ComponentModel.DataAnnotations;
using System;

namespace ContosoUniversity.ViewModels.University
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
        public int StudentCount { get; set; }
    }
}