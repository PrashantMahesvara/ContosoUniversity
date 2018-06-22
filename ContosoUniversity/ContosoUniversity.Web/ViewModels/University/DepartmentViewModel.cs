using ContosoUniversity.Web.Models;
using System.Collections.Generic;

namespace ContosoUniversity.Web.ViewModels.University
{
    public class DepartmentViewModel
    {
        public Department Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public Instructor Instructor { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
    }
}