using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels.University
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }

        public Student Student { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }

        //public Instructor Instructor { get; set; }
        //public virtual IEnumerable<Instructor> Instructors { get; set; }

        //public Department Department { get; set; }
        //public virtual IEnumerable<Department> Departments { get; set; }

        public Enrollment Enrollment { get; set; }
        public  virtual IEnumerable<Enrollment> Enrollments { get; set; }

        public int CoursesCount { get; set; }
    }
}