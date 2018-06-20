using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class CourseInstructor
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }

    }
}