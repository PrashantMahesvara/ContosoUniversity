using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ContosoUniversity.Controllers
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

            if (!String.IsNullOrEmpty(searchString))
            {
                instructors = _db.Instructors.Where(s =>
                s.LastName.ToLower().Contains(searchString.ToLower())
                ||
                s.FirstMiddleName.ToLower().Contains(searchString.ToLower()));
            }

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
            return View(instructors.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var instructorDetails = _db.Instructors.Find(id);
            if (instructorDetails == null)
                return HttpNotFound();

            return View(instructorDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName, FirstMiddleName, HireDate")]Instructor instructor)
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
        public ActionResult Edit(int? id)
        {
            var instructorDetails = _db.Instructors.Find(id);

            if (instructorDetails == null)
                return HttpNotFound();

            return View(instructorDetails);
        }

        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(instructor).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            Instructor instructor = _db.Instructors.Find(id);

            if (instructor == null)
                return HttpNotFound();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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