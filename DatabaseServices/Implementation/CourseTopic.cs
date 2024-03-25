using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class CourseTopic : ICourseTopic
    {
        private IRepository<tblcourse_topics> ctrepo;
        private IRepository<tbltraining_topics> trepo;
        private IRepository<tbltraining_courses> crepo;
        
        public CourseTopic(IRepository<tblcourse_topics> ctrepo, IRepository<tbltraining_topics> trepo,IRepository<tbltraining_courses> crepo)
        {
            this.ctrepo = ctrepo;
            this.trepo = trepo;
            this.crepo = crepo;
        }

        public void AddCourseTopic(tblcourse_topics ct)
        {
            ctrepo.Create(ct);
        }

        public List<tbltraining_topics> FetchCourseTopic()
        {
            return trepo.GetAll();
        }

        public void AddCourseTopicRelationship(int courseId, int topicId)
        {
            var courseTopic = new tblcourse_topics
            {
                course_id = courseId,
                topic_id = topicId
            };
            ctrepo.Create(courseTopic);
        }

        public List<tblcourse_topics> GetCourseTopic()
        {
            List<tblcourse_topics> lst = ctrepo.GetAll();
            return lst;
        }

       
    }

}
