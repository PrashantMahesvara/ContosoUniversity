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
        public IEnumerable<Course> Courses { get; set; }

        public Student Student { get; set; }
        public IEnumerable<Student> Students { get; set; }

        //public Instructor Instructor { get; set; }
        //public IEnumerable<Instructor> Instructors { get; set; }

        //public Department Department { get; set; }
        //public IEnumerable<Department> Departments { get; set; }
    }
}