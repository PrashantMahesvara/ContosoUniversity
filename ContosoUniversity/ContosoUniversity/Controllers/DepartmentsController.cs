using ContosoUniversity.Models;
using ContosoUniversity.ViewModels.University;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
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
            var listOfDepartments = _db.Departments.ToList();

            return View(listOfDepartments);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var departmentDetails = _db.Departments.Find(id);
            if (departmentDetails == null)
                return HttpNotFound();

            return View(departmentDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new DepartmentViewModel
            {
                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            var viewModel = new DepartmentViewModel
            {
                Instructors = _db.Instructors.ToList(),
                Departments = _db.Departments.ToList()
            };

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
            return View("Create", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _db.Departments.Find(id);

            if (department == null)
                return HttpNotFound();

            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department, int id)
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