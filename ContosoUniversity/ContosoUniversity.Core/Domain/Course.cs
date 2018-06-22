using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Web.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        public string Title { get; set; }

        [Display(Name = "Punti")]
        [Range(0, 5)]
        public int Credits { get; set; }

        public string Information { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}