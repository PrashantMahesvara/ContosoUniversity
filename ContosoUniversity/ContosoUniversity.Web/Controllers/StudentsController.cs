using ContosoUniversity.Web.ViewModels.University;
using ContosoUniversity.Web.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;

namespace ContosoUniversity.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var students = from s in _db.Students
                           select s;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "first_name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "first_name_desc":
                    students = students.OrderByDescending(s => s.FirstMiddleName);
                    break;
                case "first_name":
                    students = students.OrderBy(s => s.FirstMiddleName);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString)) { students = students.Where(s => s.LastName.ToLower().Contains(searchString.ToLower()) || s.FirstMiddleName.ToLower().Contains(searchString.ToLower())); }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var studentDetails = _db.Students.Find(id);

            if (studentDetails == null)
                return HttpNotFound();

            var viewModel = new StudentViewModel
            {
                Student = _db.Students.Find(id),
                Courses = _db.Courses.ToList(),
                Enrollments = _db.Enrollments.ToList(),
                Enrollment = new Enrollment()
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
        public ActionResult Create([Bind(Include = "LastName, FirstMiddleName, EnrollmentDate, Birthday, SSN")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Students.Add(student);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "unable to save changes");
                return View("Error");
            }
            return View("Create", student);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var studentDetails = _db.Students.Find(id);

            if (studentDetails == null)
                return HttpNotFound();

            var viewModel = new StudentViewModel
            {
                Student = _db.Students.Find(id),
                Courses = _db.Courses.ToList(),
                Enrollments = _db.Enrollments.ToList(),
                Enrollment = new Enrollment()
            };

            return View(studentDetails);
        }

        [HttpPost]
        public ActionResult Edit(Student student, Enrollment enrollment, int? id)
        {
            var viewModel = new StudentViewModel
            {
                Student = _db.Students.Find(id),
                Courses = _db.Courses.ToList(),
                Enrollments = _db.Enrollments.ToList(),
                Enrollment = new Enrollment()
            };

            if (ModelState.IsValid)
            {
                _db.Entry(student).State = EntityState.Modified;
                _db.Enrollments.Add(enrollment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult New(int? id)
        {
            var viewModel = new EnrollmentViewModel
            {
                Enrollment = new Enrollment(),
                Student = _db.Students.Single(x => x.Id == id),
                Courses = _db.Courses.ToList()
            };

            return View("New", viewModel);
        }

        [HttpPost]
        public ActionResult New(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _db.Enrollments.Add(enrollment);
                _db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            var student = _db.Students.Find(id);

            if (student == null)
                return HttpNotFound();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again!";
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var student = _db.Students.Find(id);
                _db.Students.Remove(student);
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