using ContosoUniversity.Web.Models;
using System.Collections.Generic;

namespace ContosoUniversity.Web.ViewModels.University
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }


        public virtual IEnumerable<Student> Students { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual IEnumerable<Instructor> Instructors { get; set; }

        public virtual Department Department { get; set; }
        public virtual IEnumerable<Department> Departments { get; set; }

        public Enrollment Enrollment { get; set; }
        public virtual IEnumerable<Enrollment> Enrollments { get; set; }

        public InstructorCourse InstructorCourse { get; set; }
        public IEnumerable<InstructorCourse> InstructorCourses { get; set; }


        public int CoursesCount { get; set; }
    }
}