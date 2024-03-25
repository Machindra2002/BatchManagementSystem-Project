using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Models;

namespace DatabaseServices.Implementation
{
    public class TopicService : ITopicService
    {
        private IRepository<tbltraining_topics> topicrepo;
        private batch_managementDBEntities db;
        public TopicService(IRepository<tbltraining_topics> topicrepo, batch_managementDBEntities db)
        {
            this.topicrepo = topicrepo;
            this.db = db;
        }

        public void AddContentToExistingTopic(tbltraining_topics topic)
        {
            if(topic == null || topic.tbltopic_contents == null)
            {
                throw new ArgumentNullException("Invalid topic or contents");
            }

            var existingTopic = db.tbltraining_topics.Include("tbltopic_contents")
                .FirstOrDefault(t=>t.topic_id==topic.topic_id);

            if(existingTopic != null)
            {
               foreach(var tc in topic.tbltopic_contents)
                {
                    existingTopic.tbltopic_contents.Add(tc);
                }
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Topic Not found");
            }
        }

        public void AddTopic(tbltraining_topics topic)
        {
           topicrepo.Create(topic);
        }

        public void DeleteTopic(int topic_id)
        {
            topicrepo.Delete(topic_id);
        }

        public List<TopicModels> GetAllTopics()
        {
            List<TopicModels> lst = new List<TopicModels>();
            foreach(var t in topicrepo.GetAll())
            {
                TopicModels tm = new TopicModels()
                {
                    topic_id = t.topic_id,
                    topic_name = t.topic_name
                };
                lst.Add(tm);
            }
            return lst;
        }

        public tbltraining_topics GetTopicById(int topic_id)
        {
            return topicrepo.GetById(topic_id);
        }

        public List<tbltraining_topics> GetTopics()
        {
            return topicrepo.GetAll();
        }

        public void UpdateTopic(tbltraining_topics topic)
        {
            topicrepo.Update(topic);
        }

       
    }
}
