using ContosoUniversity.Web.Models;
using System.Collections.Generic;

namespace ContosoUniversity.Web.ViewModels.University
{
    public class EnrollmentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Student> Students { get; set; }

        public Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public Enrollment Enrollment { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}