using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface ICourseTopic
    {
        void AddCourseTopic(tblcourse_topics ct);
        List<tblcourse_topics> GetCourseTopic();
        void AddCourseTopicRelationship(int courseId, int topicId);

        List<tbltraining_topics> FetchCourseTopic();
    }
}
