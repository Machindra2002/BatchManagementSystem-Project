using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class Student : IStudent
    {
        IRepository<tblstudent_details> studentrepo;
        
        public Student(IRepository<tblstudent_details> studentrepo)
        {
            this.studentrepo = studentrepo;
        }
        public void AddStudent(tblstudent_details student)
        {
            studentrepo.Create(student);
        }

        public void DeleteStudent(int student_id)
        {
            studentrepo.Delete(student_id);
        }

        public List<tblstudent_details> GetStudent()
        {
            return studentrepo.GetAll();
        }

        public tblstudent_details GetStudentById(int student_id)
        {
            return studentrepo.GetById(student_id);
        }

        public void UpdateStudent(tblstudent_details student)
        {
            studentrepo.Update(student);
        }
    }
}
