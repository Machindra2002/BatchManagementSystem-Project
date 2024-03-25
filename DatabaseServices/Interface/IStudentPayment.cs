using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface IStudentPayment
    {

        void AddStudentPayment(tblstudent_payments studentpayment);
        void UpdateStudentPayment(tblstudent_payments studentpayment);
        List<tblstudent_payments> GetAllStudentPayment(int registerId);
        void StudentCourseWiseFees(int courseId, float paymentAmount, DateTime paymentDate, string paymentMode, string paymentDescription);
    }
}
