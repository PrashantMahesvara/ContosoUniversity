using ContosoUniversity.Models;
using ContosoUniversity.ViewModels.University;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
        
        [HttpGet]
        public ViewResult Index(string sortOrder, string searchString)
        {
            var listOfCourses = _db.Courses.ToList();

            return View(listOfCourses);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var courseDetails = _db.Courses.Find(id);
            if (courseDetails == null)
                return HttpNotFound();

            var viewModel = new CourseViewModel
            {
                Course = courseDetails,
                Courses = _db.Courses.ToList(),
   
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


        public ActionResult Edit(string id)
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
            var viewModel = new CourseViewModel
            {
                Course = course,
                Courses = _db.Courses.ToList(),
                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

            if (ModelState.IsValid)
            {
                //_db.Entry(course).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(string id, bool? saveChangesError = false)
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
        public ActionResult Delete(string id)
        {
            try
            {
                Course course = _db.Courses.Find(id);
                _db.Courses.Remove(course);
                _db.SaveChanges();
            }
            catch (DataException ex)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
    }
}