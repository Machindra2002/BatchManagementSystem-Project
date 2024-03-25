using DatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
using Microsoft.Ajax.Utilities;

namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        
        ITopicContentService contentService;
        ITopicService topicService;

        public ContentController(ITopicContentService contentService, ITopicService topicService)
        {
            this.contentService = contentService;
            this.topicService = topicService;
        }

        public ActionResult Index()
        {
            return View();
        }


        public List<SelectListItem> GetTopic()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach(tbltraining_topics t in topicService.GetTopics())
            {
                SelectListItem select = new SelectListItem
                {
                    Text = t.topic_name,
                    Value = t.topic_id.ToString()
                };
                lst.Add(select);
            }
            return lst;
        }
        public ActionResult AddContent()
        {
            ViewBag.topic = GetTopic();
            ViewBag.content = contentService.GetContent();
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(tbltopic_contents tc)
        {
            contentService.AddContent(tc);
            ViewBag.msg = "content added successfully";
            return RedirectToAction("AddContent");
        }

        public ActionResult EditContent(int id)
        {
            ViewBag.topic = GetTopic();
            ViewBag.content = contentService.GetContent();
            tbltopic_contents content = contentService.GetContentById(id);
            return View(content);
        }

        [HttpPost]
        public ActionResult EditContent(tbltopic_contents tc)
        {
            contentService.UpdateContent(tc);
            ViewBag.msg = "content update successfully";
            return RedirectToAction("AddContent");
        }

        public ActionResult DeleteContent(int id)
        {
            contentService.DeletTopicContent(id);
            return RedirectToAction("AddContent");
        }
    }
}