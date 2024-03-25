using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseOperation
{
    public class CourseTopics
    {
        public int course_topics { get; set; }

        public int course_id { get; set; }

        public int topic_id { get; set; }

        public virtual tbltraining_courses tbltraining_courses { get; set; }

        public virtual tbltraining_topics tbltraining_topics { get; set; }

        public List<TopicsModel> topicmodels { get; set; }
    }

    public class TopicsModel
    {
        public int topic_id { get; set; }
        public string topic_name { get; set; }
        public bool isSelected { get; set; }
    }
}
