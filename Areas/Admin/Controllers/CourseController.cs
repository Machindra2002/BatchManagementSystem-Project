using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
using Microsoft.Ajax.Utilities;
using BatchManagementSystem.Models;

namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        ICourseService courseService;
        ICourseFees coursefeesService;
        ICourseTopic ctservice;
        ITopicService topicService;
        public CourseController(ICourseService courseService, ITopicService topicService, ICourseFees coursefeesService, ICourseTopic ctservice)
        {
            this.courseService = courseService;
            this.coursefeesService = coursefeesService;
            this.ctservice = ctservice;
            this.topicService= topicService;
    }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCourse()
        {
            ViewBag.courses = courseService.GetCourses();
            return View();
        }

      /*  [HttpPost]
        public ActionResult AddCourse(tbltraining_courses tc)
        {
            //courseService.AddCourse(tc);
            return RedirectToAction("AddCourse");
        }*/

        public ActionResult EditCourse(int id)
        {
            tbltraining_courses course = courseService.GetCourseById(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult EditCourse(tbltraining_courses tc)
        {
            courseService.UpdateCourse(tc);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }

       // -------------------------------Course-CourseFees---------------------------------------

        public ActionResult AddCourse_CourseFees()
        {
            var lst = courseService.GetCourses();
            return View(lst);
        }
        [HttpPost]
        public string AddCourse_CourseFees(tbltraining_courses course)
        {
            courseService.AddCourse(course);
            return "Course and CourseFee added Successfully";
        }

        public JsonResult FetchTopics()
        {
            var lst = topicService.GetAllTopics();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public string AddCourseTopic(List<tblcourse_topics> coursetopic)
        {
            foreach(var ct in coursetopic)
            {
                courseService.AddCourseTopics(ct);
            }
            return "course and multiple topics submitted successfully";
        }

    }
}