using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class CourseFeesService : ICourseFees
    {
        private IRepository<tbltraining_course_fees> coursefeesrepo;
        private IRepository<tbltraining_courses> courserepo;
        public CourseFeesService(IRepository<tbltraining_course_fees> coursefeesrepo, IRepository<tbltraining_courses> courserepo)
        {
            this.coursefeesrepo = coursefeesrepo;
            this.courserepo = courserepo;
        }

        public void AddCourseFees(tbltraining_course_fees coursefees)
        {
            coursefeesrepo.Create(coursefees);
        }

        public void DeleteCourseFees(int coursefees_id)
        {
            coursefeesrepo.GetById(coursefees_id);
        }

        public List<tbltraining_course_fees> GetCourseByFees(int course_id)
        {
            return coursefeesrepo.GetAll().Where(e => e.course_id.Equals(course_id)).ToList();
        }

        public List<tbltraining_course_fees> GetCourseFees()
        {
           return coursefeesrepo.GetAll();
        }

        public tbltraining_course_fees GetCourseFeesById(int coursefees_id)
        {
            return coursefeesrepo.GetById(coursefees_id);
        }

        public void UpdateCourseFees(tbltraining_course_fees coursefees)
        {
            coursefeesrepo.Update(coursefees);
        }

    }
}
