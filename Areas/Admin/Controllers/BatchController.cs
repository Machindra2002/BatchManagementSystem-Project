using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
using Microsoft.Ajax.Utilities;
using System.Web.Helpers;

namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class BatchController : Controller
    {
        IBatchService batchservice;
        ITopicService topicService;
        ITrainers trainerservice;
        IStudentRegistration studregister;
        public BatchController(IBatchService batchservice,ITrainers trainerservice, ITopicService topicService, IStudentRegistration studregister)
        {
            this.batchservice = batchservice;
            this.topicService = topicService;
            this.trainerservice = trainerservice;
            this.studregister = studregister;
        }

        public JsonResult GetTopicWiseStudent(int id)
        {
            var lst = batchservice.TopicWiseStudent(id);
            return Json(lst);
        }

        [HttpGet]
        public JsonResult GetAllTopic()
        {
            var st = GetTopic();
            return Json(st, JsonRequestBehavior.AllowGet);    
        }
        public List<SelectListItem> GetTopic()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (tbltraining_topics t in topicService.GetTopics())
            {
                SelectListItem topic = new SelectListItem()
                {
                    Text = t.topic_name,
                    Value = t.topic_id.ToString(),
                };
                lst.Add(topic);
            }
            return lst;
        }

        public List<SelectListItem> GetTrainer()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (tbltrainer tr in trainerservice.GetTrainers())
            {
                SelectListItem trainer = new SelectListItem()
                {
                    Text = tr.trainer_name,
                    Value = tr.trainer_id.ToString(),
                };
                lst.Add(trainer);
            }
            return lst;
        }

        public ActionResult Index()
        {
            ViewBag.topics = GetTopic();
            ViewBag.trainer = GetTrainer();
            ViewBag.batches = batchservice.GetAllBatches();
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblbatch batch)
        {
            batchservice.CreateBatch(batch);
            return RedirectToAction("Index");
        }
      
        public ActionResult EditBatch(int id)
        {
            ViewBag.topics = GetTopic();
            ViewBag.trainer = GetTrainer();
            tblbatch b = batchservice.GetBatch(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult EditBatch(tblbatch batch)
        {
            batchservice.UpdateBatch(batch);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBatch(int id)
        {
            batchservice.DeleteBatch(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult GetCourseWiseStudent(int cid)
        {
            ViewBag.studentregister =  studregister.StudentRegistraionCourseDetails(cid);
            return RedirectToAction("Index");
        }

        public ActionResult AddStudentInBatch()
        {
            return View();
        }
    }
}