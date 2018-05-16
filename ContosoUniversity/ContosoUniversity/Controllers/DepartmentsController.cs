using ContosoUniversity.Models;
using ContosoUniversity.ViewModels.University;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        public ActionResult Index()
        {
            return View(_db.Departments.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var departmentDetails = _db.Departments.Find(id);
            if (departmentDetails == null)
                return HttpNotFound();

            return View(departmentDetails);
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
        public ActionResult Edit(int? id)
        {
            var editDepartment = _db.Departments.Find(id);

            if(editDepartment == null)
                return HttpNotFound();

            return View(editDepartment);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.Entry(department).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {             
            }
            return View(department);
        }

        
    }
}