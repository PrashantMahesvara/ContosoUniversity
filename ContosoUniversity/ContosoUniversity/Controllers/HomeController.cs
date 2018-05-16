using ContosoUniversity.Models;
using ContosoUniversity.ViewModels.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from student in _db.Students
                                                   group student by student.EnrollmentDate into dateGroup
                                    select new EnrollmentDateGroup()
                                    {
                                        EnrollmentDate = dateGroup.Key,
                                        StudentCount = dateGroup.Count()

                                    };

            ViewBag.Message = "Your application description page.";

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}