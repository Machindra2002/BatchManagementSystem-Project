using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class StudentRegistration:IStudentRegistration
    {
        private IRepository<tblstudent_registrations> studregisterrepo;
        private IRepository<tblstudent_details> studentdetailsrepo;
        private IRepository<tbltraining_courses> studenttrainingcoursesrepo;
        public StudentRegistration(IRepository<tblstudent_registrations> studregisterrepo, IRepository<tblstudent_details> studentdetailsrepo, IRepository<tbltraining_courses> studenttrainingcoursesrepo)
        {
            this.studregisterrepo = studregisterrepo;
            this.studentdetailsrepo = studentdetailsrepo;
            this.studenttrainingcoursesrepo = studenttrainingcoursesrepo;
        }

        public void AddStudentCourse(tblstudent_registrations studentcourse)
        {
            studregisterrepo.Create(studentcourse);
        }

        public void AddStudentCourseWisePayment(int courseId)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentCourse(int registrationId)
        {
            studregisterrepo.Delete(registrationId);
        }

        public List<tblstudent_registrations> GetAllRegisterStudent()
        {
            return studregisterrepo.GetAll();
        }

        public List<tblstudent_registrations> StudentRegistraionCourseDetails(int coursetId)
        {
            return studregisterrepo.GetAll().Where(e=>e.course_id.Equals(coursetId)).ToList();
        }

        public void UpdateStudentCourse(tblstudent_registrations studentcourse)
        {
            studregisterrepo.Update(studentcourse);
        }
    }
}
