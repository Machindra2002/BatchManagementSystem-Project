using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class TopicController : Controller
    {
       ITopicService topicService;
       ITopicContentService topicContentService;
        public TopicController(ITopicService topicService, ITopicContentService topicContentService)
        {
            this.topicService = topicService;
            this.topicContentService = topicContentService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Topic()
        {
            ViewBag.topics = topicService.GetTopics();
            return View();
        }
     /*   [HttpPost]
        public ActionResult Topic(tbltraining_topics t)
        {
            topicService.AddTopic(t);
            ViewBag.msg = "Topic added successfully";
            return RedirectToAction("Topic");
        }*/

        public ActionResult EditTopic(int id)
        {
            ViewBag.topics = topicService.GetTopics();
            tbltraining_topics topic = topicService.GetTopicById(id);
            return View(topic);
        }

        [HttpPost]
        public ActionResult EditTopic(tbltraining_topics t)
        {
            topicService.UpdateTopic(t);
            ViewBag.edittopic = "topic edit successfully";
            return RedirectToAction("Topic");
        }
       
        public ActionResult DeleteTopic(int id)
        {
            topicService.DeleteTopic(id);
            return RedirectToAction("Topic");
        }

        //--------------------------------------------Topic-Content---------------------------------
        public ActionResult AddTopicContent()
        {
            ViewBag.topics = topicService.GetTopics();
            ViewBag.contents = topicContentService.GetContent();
            return View();
        }

        [HttpPost]
        public string AddTopicContent(tbltraining_topics topic)
        {
            topicService.AddTopic(topic);
            return "Topic Added Sucessfully";
        }
       
        [HttpPost]
        public string AddContentToExistingTopic(tbltraining_topics topic)
        {
            topicService.AddContentToExistingTopic(topic);
            return "Content added to existing topic successfully";
        }

        public JsonResult EditTopicData(int id)
        {
            tbltraining_topics t = topicService.GetTopicById(id);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

    }
}