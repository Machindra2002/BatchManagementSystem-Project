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
    public class BatchStudentController : Controller
    {
        IStudentRegistration regstudrepo;
        IBatchStudentService batchStudentService;
        public BatchStudentController(IStudentRegistration regstudrepo, IBatchStudentService batchStudentService)
        {
            this.regstudrepo = regstudrepo;
            this.batchStudentService = batchStudentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudentInBatch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentInBatch(tblbatch_students batchstudent)
        {
           batchStudentService.AddStudentBatch(batchstudent);
            return View();
        }
    }
}