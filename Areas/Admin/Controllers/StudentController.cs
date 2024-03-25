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
using static System.Net.WebRequestMethods;
using System.IO;
using BatchManagementSystem.Models;

namespace BatchManagementSystem.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        IStudent studservice;
        IStudentProfile studentservice;
        IStudentRegistration studentregistration;
        IStudentPayment studentpayment;
        ICourseService courseService;

        ExtraBL ebl;
        public StudentController(IStudent studservice,IStudentProfile studentservice, ICourseService courseService,
        IStudentRegistration studentregistration, IStudentPayment studentpayment)
        {
            this.studservice = studservice; 
            this.studentservice = studentservice;
            this.studentregistration = studentregistration;
            this.studentpayment = studentpayment;
            this.courseService = courseService;
            ebl = new ExtraBL();
        }
        public ActionResult Index()
        {
            ViewBag.courses = GetCourses();
            ViewBag.student = studservice.GetStudent();
            return View();
        }

        /*[HttpPost]
        public ActionResult Index(tblstudent_details s , HttpPostedFileBase profilephoto)
        {
            string password = ebl.GeneratePassword(8);
            s.password = password;
            string subject = "Login Credintial";
            string message = "<h2> Dear "+ s.student_name +"</h2><p> Your Login Id = "+s.email_address+" and Pasword =" + password +"</p></br><h4>Regards, </br>Machindra";
            ebl.SendMail(s.email_address, subject, message);

            string sphoto = s.student_name + Path.GetExtension(profilephoto.FileName);
            string imagepath = Server.MapPath("~/Images/" + sphoto);
            profilephoto.SaveAs(imagepath);
            s.profile_photo = sphoto;

            studservice.AddStudent(s);
            ViewBag.msg = "Student added Succeffully";
            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public ActionResult Index(Student_RegisterModel s, HttpPostedFileBase profilephoto)
        {
            string password = ebl.GeneratePassword(8);
            s.password = password;
            string subject = "Login Credintial";
            string message = "<h2> Dear " + s.student_name + "</h2><p> Your Login Id = " + s.email_address + " and Pasword =" + password + "</p></br><h4>Regards, </br>Machindra";
            ebl.SendMail(s.email_address, subject, message);

            string sphoto = s.student_name + Path.GetExtension(profilephoto.FileName);
            string imagepath = Server.MapPath("~/Images/" + sphoto);
            profilephoto.SaveAs(imagepath);
            s.profile_photo = sphoto;

            tblstudent_details st = new tblstudent_details()
            {
                student_id = s.student_id,
                student_name = s.student_name,
                email_address = s.email_address,
                birth_date = s.birth_date,
                gender = s.gender,
                profile_photo = s.profile_photo,
                mobile_number = s.mobile_number,
                qualification = s.qualification,
                password = s.password
            };
            studservice.AddStudent(st);

            var sid = st.student_id;
            tblstudent_registrations sr = new tblstudent_registrations()
            {
                registration_id = s.registration_id,
                student_id = sid,
                course_id = s.course_id,
                discount = s.discount,
                registration_date = s.registration_date,
            };

            studentregistration.AddStudentCourse(sr);
            ViewBag.msg = "Student added Succeffully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            tblstudent_details s = studservice.GetStudentById(id);
            return View(s);
        }

        /* [HttpPost]
         public ActionResult EditStudent(tblstudent_details s, HttpPostedFileBase profilephoto)
         {
             string sphoto = s.student_name + Path.GetExtension(profilephoto.FileName);
             string imagepath = Server.MapPath("~/Images/" + sphoto);
             profilephoto.SaveAs(imagepath);
             s.profile_photo = sphoto;

             studservice.UpdateStudent(s);
             return RedirectToAction("Index");
         }*/
        [HttpPost]
        public ActionResult EditStudent(tblstudent_details s, HttpPostedFileBase profilephoto)
        {
            tblstudent_details existingStudent = studservice.GetStudentById(s.student_id); // Assuming 'student_id' is the primary key of the student

            if (!string.IsNullOrEmpty(existingStudent.email_address) && !string.IsNullOrEmpty(existingStudent.password))
            {
                s.email_address = existingStudent.email_address;
                s.password = existingStudent.password;
            }
            else
            {
                string password = ebl.GeneratePassword(8);
                s.password = password;
                string subject = "Login Credintial";
                string message = "<h2> Dear " + s.student_name + "</h2><p> Your Login Id = " + s.email_address + " and Pasword =" + password + "</p></br><h4>Regards, </br>Machindra";
                ebl.SendMail(s.email_address, subject, message);
            }

            string sphoto = s.student_name + Path.GetExtension(profilephoto.FileName);
            string imagepath = Server.MapPath("~/Images/" + sphoto);
            profilephoto.SaveAs(imagepath);
            s.profile_photo = sphoto;

            studservice.UpdateStudent(s);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            studservice.DeleteStudent(id);
            return RedirectToAction("Index");
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