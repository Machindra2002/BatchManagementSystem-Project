using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface IStudentProfile
    {
        tblstudent_details GetStudentById(int studid);
        void UpdateStudent(tblstudent_details student);
        void UpdateStudentPhoto(int studentId, string profilephoto);
        void UpdateStudentPassword(int studentId, string password);
        List<tbltraining_courses> GetCourseByStudentId(int studentId);
        List<tblbatch_schedule> GetBatchSheduleByBatchId(int batchId);
        List<tblschedule_attendance> GetAttendenceByStudentId(int studentId);
        List<tblstudent_payments> GetPaymentsByStudentId(int studentId);
    }
}
