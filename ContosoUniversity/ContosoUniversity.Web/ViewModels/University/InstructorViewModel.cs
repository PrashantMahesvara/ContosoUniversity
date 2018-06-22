using ContosoUniversity.Web.Models;
using System.Collections.Generic;

namespace ContosoUniversity.Web.ViewModels.University
{
    public class InstructorViewModel
    {
        public Instructor Instructor { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }

        public Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public InstructorCourse InstructorCourse { get; set; }
        public IEnumerable<InstructorCourse> InstructorCourses { get; set; }
    }
}