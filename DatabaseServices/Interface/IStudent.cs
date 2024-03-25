using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface IStudent
    {
        void AddStudent(tblstudent_details student);
        void UpdateStudent(tblstudent_details student);
        void DeleteStudent(int student_id);
        List<tblstudent_details> GetStudent();
        tblstudent_details GetStudentById(int student_id);


    }
}
