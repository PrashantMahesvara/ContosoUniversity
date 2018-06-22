using ContosoUniversity.Web.Models;
using ContosoUniversity.Web.ViewModels.University;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ContosoUniversity.Web.Controllers
{
    public class DepartmentsController : Controller
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
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CreditsSortParm = sortOrder == "StartDate" ? "startdate_desc" : "StartDate";
            var departments = from c in _db.Departments
                          select c;

            switch (sortOrder)
            {
                case "name_desc":
                    departments = departments.OrderByDescending(s => s.Name);
                    break;
                case "StartDate":
                    departments = departments.OrderBy(s => s.StartDate);
                    break;
                case "startdate_desc":
                    departments = departments.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    departments = departments.OrderBy(s => s.Name);
                    break;
            }


            var listOfDepartments = _db.Departments.ToList();

            var viewModel = new DepartmentViewModel
            {
                Departments = _db.Departments.ToList(),
                Instructors = _db.Instructors.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var departmentDetails = _db.Departments.Include(i => i.Instructor).SingleOrDefault(m => m.Id == id);
            if (departmentDetails == null)
                return HttpNotFound();

            var viewModel = new DepartmentViewModel
            {
                Department = departmentDetails,
                Departments = _db.Departments.ToList(),
                Instructors = _db.Instructors.ToList()
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
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Departments.Add(department);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "unable to save changes");
            }
            return View("Create", department);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _db.Departments.Find(id);

            if (department == null)
                return HttpNotFound();

            var viewModel = new DepartmentViewModel
            {
                Department = department,
                Departments = _db.Departments.ToList(),
                Instructors = _db.Instructors.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(department).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            var department = _db.Departments.Find(id);

            if (department == null)
                return HttpNotFound();

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again!";
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var department = _db.Departments.Find(id);
                _db.Departments.Remove(department);
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
