using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseServices.Interface;
using DatabaseOperation;
using System.Data.Entity.Core.Common.CommandTrees;

namespace DatabaseServices.Implementation
{
    public class StudentProfile:IStudentProfile
    {
        private IRepository<tblstudent_details> studrepo;
        private IRepository<tblstudent_registrations> studregisterrepo;
        private IRepository<tblstudent_payments> paymentrepo;
        private IRepository<tbltraining_courses> courserepo;
        private IRepository<tblbatch_schedule> shedulerepo;
        private IRepository<tblschedule_attendance> attendencerepo;
        
        public StudentProfile(IRepository<tblstudent_details> studrepo,IRepository<tblstudent_registrations> studregisterrepo,IRepository<tblstudent_payments> paymentrepo,IRepository<tbltraining_courses> courserepo,IRepository<tblbatch_schedule> shedulerepo, IRepository<tblschedule_attendance>attendencerepo)
        {
            this.studrepo = studrepo;
            this.studregisterrepo = studregisterrepo;
            this.courserepo = courserepo;
            this.shedulerepo = shedulerepo;
            this.attendencerepo = attendencerepo;
            this.paymentrepo = paymentrepo;
        }

        // mark student batch wise attendence
        public List<tblschedule_attendance> GetAttendenceByStudentId(int studentId)
        {
            return attendencerepo.GetAll().Where(sa => sa.registration_id == studentId).ToList();
        }

        public List<tblbatch_schedule> GetBatchSheduleByBatchId(int batchId)
        {
            return shedulerepo.GetAll().Where(b => b.batch_id==batchId).ToList();
        }

        //student view his course list 
        public List<tbltraining_courses> GetCourseByStudentId(int studentId)
        {
            var courses = (from registration in studregisterrepo.GetAll()
                           where registration.student_id == studentId
                           join course in courserepo.GetAll() on registration.course_id equals course.course_id
                           select course).ToList();
            return courses;
        }

        //student view his course payment details 
        public List<tblstudent_payments> GetPaymentsByStudentId(int studentId)
        {
            return paymentrepo.GetAll().Where(p => p.registration_id == studentId).ToList();
        }

        public tblstudent_details GetStudentById(int studid)
        {
           return studrepo.GetById(studid);
        }

        public void UpdateStudent(tblstudent_details student)
        {
            studrepo.Update(student);
        }

        public void UpdateStudentPassword(int studentId, string password)
        {
            var student = studrepo.GetById(studentId);
            if(student != null)
            {
                student.password = password;
                studrepo.Update(student);
            }
        }

        public void UpdateStudentPhoto(int studentId, string profilephoto)
        {
            var student = studrepo.GetById(studentId);
            if(student != null)
            {
                student.profile_photo = profilephoto;
                studrepo.Update(student);
            }
        }
       
    }
}
