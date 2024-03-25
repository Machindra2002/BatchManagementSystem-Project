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
    public class CourseFeesController : Controller
    {
        ICourseService courseservice;
        ICourseFees coursefees;

        public CourseFeesController(ICourseService courseservice, ICourseFees coursefees)
        {
            this.courseservice = courseservice;
            this.coursefees = coursefees;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCourseFees()
        {
            ViewBag.courses = GetCourse();
            ViewBag.coursefeess = coursefees.GetCourseFees();
            return View();
        }
        [HttpPost]
        public ActionResult AddCourseFees(tbltraining_course_fees cf)
        {
            coursefees.AddCourseFees(cf);
            return RedirectToAction("AddCourseFees");
        }
        public List<SelectListItem> GetCourse()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (tbltraining_courses c in courseservice.GetCourses())
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

       /* [HttpPost]
        public ActionResult AddCourseFees(tbltraining_courses tc, tbltraining_course_fees cf)
        {
            courseservice.AddCourse(tc);
            coursefees.AddCourseFees(cf);
            return RedirectToAction("AddCourseFees");
        }*/

    }
}