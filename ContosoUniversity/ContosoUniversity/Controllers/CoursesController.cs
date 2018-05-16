using ContosoUniversity.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CourseSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var courses = from s in _db.Courses select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = _db.Courses.Where(s =>
                s.Title.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(s => s.Title);
                    break;
                default:
                    courses = courses.OrderBy(s => s.Title);
                    break;
            }

            return View(_db.Courses.ToList());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var courseDetails = _db.Courses.Find(id);
            if (courseDetails == null)
                return HttpNotFound();

            return View(courseDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Title, Credits")]Course course)
        {
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
            return View("Create", course);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var courseDetails = _db.Courses.Find(id);

            if (courseDetails == null)
                return HttpNotFound();

            return View(courseDetails);
        }

        [HttpPost]
        public ActionResult Edit(Course course, string id)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(course).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", course);
        }

        public ActionResult Delete(string id)
        {
            var courseToDelete = _db.Courses.Find(id);

            if (courseToDelete == null)
                return HttpNotFound();

                return View(courseToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id, Course course)
        {
            course = _db.Courses.Find(id);

            if (course == null)
                return HttpNotFound();

            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}