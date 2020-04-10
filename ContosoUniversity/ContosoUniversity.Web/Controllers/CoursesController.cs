using ContosoUniversity.Web.Models;
using ContosoUniversity.Web.ViewModels.University;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ContosoUniversity.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        public ActionResult Index(int? SelectedDepartment, string sortOrder)
        {
            var departments = _db.Departments.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedDepartment = new SelectList(departments, "Id", "Name", SelectedDepartment);
            int departmentID = SelectedDepartment.GetValueOrDefault();
            IQueryable<Course> courses = _db.Courses
            .Where(c => !SelectedDepartment.HasValue || c.DepartmentId == departmentID)
            .OrderBy(d => d.Id)
            .Include(d => d.Department);
            var sql = courses.ToString();
            return View(courses.ToList());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var courseDetails = _db.Courses.Find(id);
            if (courseDetails == null)
                return HttpNotFound();

            var viewModel = new CourseViewModel
            {
                Course = courseDetails,
                Courses = _db.Courses.ToList(),
                Enrollments = _db.Enrollments.ToList(),
                Students = _db.Students.ToList(),
                InstructorCourses = _db.InstructorCourse.ToList(),
                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Courses = _db.Courses.ToList(),
                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            var viewModel = new CourseViewModel
            {
                Courses = _db.Courses.ToList(),

                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

            try
            {
                if (ModelState.IsValid)
                {
                    _db.Courses.Add(course);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "unable to save changes");
            }
            return View("Create", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course = _db.Courses.Find(id);

            if (course == null)
                return HttpNotFound();

            var viewModel = new CourseViewModel
            {
                Course = course,
                Courses = _db.Courses.ToList(),
                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(course).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            Course course = _db.Courses.Find(id);

            if (course == null)
                return HttpNotFound();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again!";
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Course course = _db.Courses.Find(id);
                _db.Courses.Remove(course);
                _db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
    }
}