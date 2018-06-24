using ContosoUniversity.Web.Models;
using ContosoUniversity.Web.ViewModels.University;
using PagedList;
using System;
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

        //public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        //{       
        //    var courses = from c in _db.Courses.Include(d => d.Department)
        //                   select c;

        //    ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        //    ViewBag.CreditsSortParm = sortOrder == "Credits" ? "credits_desc" : "Credits";

        //    switch (sortOrder)
        //    {
        //        case "title_desc":
        //            courses = courses.OrderByDescending(c => c.Title);
        //            break;
        //        case "Credits":
        //            courses = courses.OrderBy(c => c.Credits);
        //            break;
        //        case "credits_desc":
        //            courses = courses.OrderByDescending(c => c.Credits);
        //            break;
        //        default:
        //            courses = courses.OrderBy(c => c.Title);
        //            break;
        //    }

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewBag.CurrentFilter = searchString;

        //    if (!String.IsNullOrEmpty(searchString)) { courses = courses.Where(s => s.Title.ToLower().Contains(searchString.ToLower()) || s.Title.ToLower().Contains(searchString.ToLower())); }

        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(courses.ToPagedList(pageNumber, pageSize));
        //}

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