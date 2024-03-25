using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class StudentRegisterController : Controller
    {
        IStudent studrepo;
        IStudentRegistration registration;
        ICourseService courseService;

        public StudentRegisterController(IStudent studrepo, IStudentRegistration registration, ICourseService courseService)
        {
            this.studrepo = studrepo;
            this.registration = registration;
            this.courseService = courseService;
        }

        public ActionResult Index()
        {
            ViewBag.student = GetStudents();
            ViewBag.courses = GetCourses();
            ViewBag.studregistration = registration.GetAllRegisterStudent();
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblstudent_registrations studregister) 
        {
            registration.AddStudentCourse(studregister);
            return RedirectToAction("Index");
        }

        public List<SelectListItem> GetStudents()
        {
            List<SelectListItem> lst = new List<SelectListItem> ();
            foreach(tblstudent_details s in studrepo.GetStudent())
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = s.student_name,
                    Value = s.student_id.ToString(),
                };
                lst.Add(item);
            }
            return lst;
        }
        public List<SelectListItem> GetCourses()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (tbltraining_courses c in courseService.GetCourses())
            {
                SelectListItem item = new SelectListItem()
                {
                    Text = c.course_name,
                    Value = c.course_id.ToString(),
                };
                lst.Add(item);
            }
            return lst;
        }

        
    }
}