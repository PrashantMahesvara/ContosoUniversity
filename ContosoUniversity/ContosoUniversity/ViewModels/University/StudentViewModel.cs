using ContosoUniversity.Models;
using System.Collections.Generic;

namespace ContosoUniversity.ViewModels.University
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Student> Students { get; set; }

        public Enrollment Enrollment { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }

        public Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}