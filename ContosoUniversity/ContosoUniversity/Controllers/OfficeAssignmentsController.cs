using ContosoUniversity.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        public ActionResult Index()
        {
            return View(_db.OfficeAssignments.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var officeAssignments = _db.OfficeAssignments.Find(id);
            if (officeAssignments == null)
                return HttpNotFound();

            return View(officeAssignments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorId, Location")]OfficeAssignment officeAssignment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.OfficeAssignments.Add(officeAssignment);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "unable to save changes");
            }
            return View("Create", officeAssignment);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var officeAssignment = _db.OfficeAssignments.Find(id);

            if (officeAssignment == null)
                return HttpNotFound();

            return View(officeAssignment);
        }

        [HttpPost]
        public ActionResult Edit(OfficeAssignment officeAssignment, int? id)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(officeAssignment).State = EntityState.Modified;
                _db.OfficeAssignments.Add(officeAssignment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officeAssignment);
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            OfficeAssignment officeAssignment = _db.OfficeAssignments.Find(id);

            if (officeAssignment == null)
                return HttpNotFound();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again!";
            }
            return View(officeAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                OfficeAssignment officeAssignment = _db.OfficeAssignments.Find(id);
                _db.OfficeAssignments.Remove(officeAssignment);
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