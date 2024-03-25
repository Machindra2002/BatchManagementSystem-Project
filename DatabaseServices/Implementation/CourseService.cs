using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class CourseService : ICourseService
    {
        private IRepository<tbltraining_courses> courserepo;
        private IRepository<tblcourse_topics> ctrepo;
        private IRepository<tbltraining_course_fees> feeRepo;
        public CourseService(IRepository<tbltraining_courses> courserepo, IRepository<tbltraining_course_fees> feeRepo, IRepository<tblcourse_topics> ctrepo)
        {
            this.courserepo = courserepo;
            this.ctrepo = ctrepo;
            this.feeRepo= feeRepo;
        }

        public void AddCourse(tbltraining_courses course)
        {
            courserepo.Create(course);
        }

        public void AddCourseTopics(tblcourse_topics ct)
        {
            ctrepo.Create(ct);
        }

        public void DeleteCourse(int course_id)
        {
            courserepo.Delete(course_id);
        }

        public tbltraining_courses GetCourseById(int course_id)
        {
            return courserepo.GetById(course_id);
        }
      
        public List<tbltraining_courses> GetCourses()
        {
            return courserepo.GetAll();
        }

        public void UpdateCourse(tbltraining_courses course)
        {
            courserepo.Update(course);
        }

    }
}
