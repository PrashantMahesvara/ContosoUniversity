using ContosoUniversity.Models;
using System.Collections.Generic;

namespace ContosoUniversity.ViewModels.University
{
    public class DepartmentViewModel
    {
        //public Department Department { get; set; }
        //public IEnumerable<Department> Departments { get; set; }

        //public Instructor Instructor { get; set; }
        //public IEnumerable<Instructor> Instructors { get; set; }

        public Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}