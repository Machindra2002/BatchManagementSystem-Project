using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
using BatchManagementSystem.EmailPassword;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class TrainerController : Controller
    {
        ITrainers trainerservice;
        ITrainerTopic trainertopics;
        ExtraBL ebl;
        public TrainerController(ITrainers trainerservice, ITrainerTopic trainertopics, ExtraBL ebl)
        {
            this.trainerservice = trainerservice;
            this.trainertopics = trainertopics;
            //ebl  = new ExtraBL();
            this.ebl = ebl;
        }

        public ActionResult Index()
        {
            ViewBag.trainer = trainerservice.GetTrainers();
            return View();
        }

        [HttpPost]
        public ActionResult Index(tbltrainer trainer)
        {
            string password = ebl.GeneratePassword(10);
            trainer.password = password;
            string subject = "Login Credintial"; ;
            string message = "<h2> Dear " + trainer.trainer_name + "</h2><p> Your Login Id = " + trainer.email_address + " and Password = " + password + "</p></br><h4>Regards, </br>Machindra";

            ebl.SendMail(trainer.email_address, subject, message);
            trainerservice.AddTrainer(trainer);
            ViewBag.msg = "Trainer Added Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTrainer(int id)
        {
            //tbltrainer t = trainerservice.GetTrainerById(id);
            tbltrainer t = trainerservice.GetTrainerById(id);
            if(t.password != null)
            {
                tbltrainer trainer = trainerservice.GetTrainerById(t.trainer_id);
                t.password = trainer.password;
            }
            return View(t);
        }
        [HttpPost]
        public ActionResult EditTrainer(tbltrainer trainer)
        {
            trainerservice.UpadateTrainer(trainer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            trainerservice.DeleteTrainer(id);
            return RedirectToAction("Index");
        }
    }
}