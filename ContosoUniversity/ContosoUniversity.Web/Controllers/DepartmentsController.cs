using ContosoUniversity.Web.ViewModels.University;
using ContosoUniversity.Web.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data;
using System.Linq;
using PagedList;
using System;

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


        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var departments = from d in _db.Departments.Include(d => d.Instructor)
                          select d;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BudgetSortParm = sortOrder == "budget" ? "budget_desc" : "budget";
            ViewBag.AdminSortParm = sortOrder == "admin" ? "admin_desc" : "admin";

            switch (sortOrder)
            {
                case "name_desc":
                    departments = departments.OrderByDescending(d => d.Name);
                    break;
                case "budget":
                    departments = departments.OrderBy(s => s.Budget);
                    break;
                case "budget_desc":
                    departments = departments.OrderByDescending(s => s.Budget);
                    break;
                case "admin":
                    departments = departments.OrderBy(s => s.Instructor.FullName);
                    break;
                case "admin_desc":
                    departments = departments.OrderByDescending(s => s.Instructor.FullName);
                    break;
                default:
                    departments = departments.OrderBy(s => s.Name);
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

            if (!String.IsNullOrEmpty(searchString)) { departments = departments.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) ); }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(departments.ToPagedList(pageNumber, pageSize));
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
