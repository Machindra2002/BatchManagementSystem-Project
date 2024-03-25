using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;

namespace DatabaseServices.Interface
{
    public interface ICourseService
    {
        void AddCourse(tbltraining_courses course);
        void UpdateCourse(tbltraining_courses course);
        void DeleteCourse(int course_id);
        List<tbltraining_courses> GetCourses();
        tbltraining_courses GetCourseById(int course_id);

        void AddCourseTopics(tblcourse_topics ct);

    }
}
