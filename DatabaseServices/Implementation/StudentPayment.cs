using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class StudentPayment : IStudentPayment
    {
        private IRepository<tblstudent_payments> studentpaymentrepo;
        private IRepository<tblstudent_registrations> studentregisterrepo;
        public StudentPayment(IRepository<tblstudent_payments> studentpaymentrepo, IRepository<tblstudent_registrations> studentregisterrepo)
        {
            this.studentpaymentrepo = studentpaymentrepo;
            this.studentregisterrepo = studentregisterrepo;
        }

        public void AddStudentPayment(tblstudent_payments studentpayment)
        {
            studentpaymentrepo.Create(studentpayment);
        }

        public List<tblstudent_payments> GetAllStudentPayment(int registerId)
        {
            return studentpaymentrepo.GetAll().Where(e=>e.registration_id.Equals(registerId)).ToList();
        }

        public void StudentCourseWiseFees(int courseId, float paymentAmount, DateTime paymentDate, string paymentMode, string paymentDescription)
        {
            var registration = studentregisterrepo.GetAll().Where(r => r.course_id == courseId);
            foreach(var registerstudent in registration)
            {
                var studentPayment = new tblstudent_payments
                {
                    registration_id = registerstudent.registration_id,
                    payment_amount = paymentAmount,
                    payment_mode = paymentMode,
                    payment_description = paymentDescription
                };
                studentpaymentrepo.Create(studentPayment);
            }
        }

        public void UpdateStudentPayment(tblstudent_payments studentpayment)
        {
            studentpaymentrepo.Update(studentpayment);
        }
    }
}
