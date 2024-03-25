using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface IStudentRegistration
    {
        void AddStudentCourse(tblstudent_registrations studentcourse);
        void UpdateStudentCourse(tblstudent_registrations studentcourse);
        void DeleteStudentCourse(int registrationId);
        List<tblstudent_registrations> GetAllRegisterStudent();
        List<tblstudent_registrations> StudentRegistraionCourseDetails(int coursetId);
        //tblstudent_details RegisterStudentDetails(int studentId);
        
    }
}
