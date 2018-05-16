using ContosoUniversity.Models;
using ContosoUniversity.ViewModels.University;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
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
            var viewModel = new StudentViewModel
            {

            };


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var students = from s in _db.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = _db.Students.Where(s =>
                s.LastName.ToLower().Contains(searchString.ToLower())
                ||
                s.FirstMiddleName.ToLower().Contains(searchString.ToLower()));
            }

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
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            var listOfStudents = _db.Students.ToList();
            return View(students.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var studentDetails = _db.Students.Find(id);
            if (studentDetails == null)
                return HttpNotFound();

            return View(studentDetails);
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
            }
            return View("Create", student);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var viewModel = new StudentViewModel
            {
                Student = _db.Students.Find(id),
                Courses = _db.Courses.ToList(),
                Enrollments = _db.Enrollments.ToList(),
                Enrollment = new Enrollment()
            };

            var studentDetails = _db.Students.Find(id);

            if (studentDetails == null)
                return HttpNotFound();

            return View(viewModel);
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

            return View(viewModel);
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
            if(ModelState.IsValid)
            {
                _db.Enrollments.Add(enrollment);
                _db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            Student student = _db.Students.Find(id);

            if (student == null)
                return HttpNotFound();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if(saveChangesError.GetValueOrDefault())
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
                Student student = _db.Students.Find(id);
                _db.Students.Remove(student);
                _db.SaveChanges();
            }
            catch(DataException ex)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            
            return RedirectToAction("Index");
        }
    }
}