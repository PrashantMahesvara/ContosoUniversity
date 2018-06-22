using ContosoUniversity.Web.Models;
using ContosoUniversity.Web.ViewModels.University;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ContosoUniversity.Web.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        [HttpGet]
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var instructors = from s in _db.Instructors
                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    instructors = instructors.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    instructors = instructors.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    instructors = instructors.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    instructors = instructors.OrderBy(s => s.LastName);
                    break;
            }

            var listOfInstructors = _db.Instructors.ToList();

            return View(listOfInstructors);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var instructorDetails = _db.Instructors.Find(id);
            if (instructorDetails == null)
                return HttpNotFound();

            var viewModel = new InstructorViewModel
            {
                Instructor = instructorDetails,
                Instructors = _db.Instructors.ToList(),
                Courses = _db.Courses.ToList(),
                InstructorCourses = _db.InstructorCourse.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Instructors.Add(instructor);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "unable to save changes");
            }
            return View("Create", instructor);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var instructor = _db.Instructors.Find(id);

            if (instructor == null)
                return HttpNotFound();

            return View(instructor);
        }

        [HttpPost]
        public ActionResult Edit(Instructor instructor, string id)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(instructor).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            var instructor = _db.Instructors.Find(id);

            if (instructor == null)
                return HttpNotFound();

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again!";
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Instructor instructor = _db.Instructors.Find(id);
                _db.Instructors.Remove(instructor);
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