using ContosoUniversity.Models;
using System.Collections.Generic;

namespace ContosoUniversity.ViewModels.University
{
    public class InstructorViewModel
    {
        //public Instructor Instructor { get; set; }
        //public IEnumerable<Instructor> Instructors { get; set; }

        public Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}