using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface ICourseFees
    {
        void AddCourseFees(tbltraining_course_fees coursefees);
        void UpdateCourseFees(tbltraining_course_fees coursefees);
        void DeleteCourseFees(int coursefees_id);
        List<tbltraining_course_fees> GetCourseFees();
        tbltraining_course_fees GetCourseFeesById(int coursefees_id);
        List<tbltraining_course_fees> GetCourseByFees(int course_id);

    }
}
