using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
using DatabaseOperation;
namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class CourseModelController : Controller
    {
        ICourseTopic ctservice;
        ICourseService courseService;
        ITopicService topicService;
        public CourseModelController(ICourseService courseService, ITopicService topicService, ICourseTopic ctservice)
        {
            this.courseService = courseService;
            this.topicService = topicService;
            this.ctservice = ctservice;
        }
        public ActionResult Index()
        {
            return View();
        }

        public List<SelectListItem> GetCourse()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (tbltraining_courses c in courseService.GetCourses())
            {
                SelectListItem course = new SelectListItem()
                {
                    Text = c.course_name,
                    Value = c.course_id.ToString(),

                };
                lst.Add(course);
            }
            return lst;
        }
        public List<TopicModel> GetTopicsss()
        {
            List<TopicModel> lst = new List<TopicModel>();
            foreach(tbltraining_topics t in topicService.GetTopics())
            {
                TopicModel topic = new TopicModel()
                {
                    topic_id = t.topic_id,
                    topic_name = t.topic_name,
                    isSeletcted = false
                };
                lst.Add(topic);
            }
            return lst;
        }
        public ActionResult AddCourseTopics()
        {
            ViewBag.ct = ctservice.GetCourseTopic();
            tblcourse_topics ct = new tblcourse_topics() { topicModels = GetTopicsss() };
            ViewBag.courses = GetCourse();
            return View(ct);
        }

        [HttpPost]
        public ActionResult AddCourseTopics(tblcourse_topics t)
        {
            List<int> selectedTopics = new List<int>();
            for(int i = 0; i < t.topicModels.Count(); i++)
            {
                if (t.topicModels[i].isSeletcted)
                {
                    selectedTopics.Add(t.topicModels[i].topic_id);
                }
            }
            foreach (var selectedTopic in selectedTopics)
            {
                tblcourse_topics coursetopic = new tblcourse_topics()
                {
                    course_id = t.course_id,
                    topic_id = selectedTopic,
                };
                ctservice.AddCourseTopic(coursetopic);
            }
            return RedirectToAction("AddCourseTopics");
        }

    }
}
