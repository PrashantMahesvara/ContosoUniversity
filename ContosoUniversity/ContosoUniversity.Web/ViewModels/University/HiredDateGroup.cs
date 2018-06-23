using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Web.ViewModels.University
{
    public class HiredDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? HiredDate { get; set; }
        public int InstructorCount { get; set; }
    }
}