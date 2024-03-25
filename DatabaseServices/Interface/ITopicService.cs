using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Models;

namespace DatabaseServices.Interface
{
    public interface ITopicService
    {
        void AddTopic(tbltraining_topics topic);
        void UpdateTopic(tbltraining_topics topic);
        void DeleteTopic(int topic_id);
        List<tbltraining_topics> GetTopics();
        tbltraining_topics GetTopicById(int topic_id);
        void AddContentToExistingTopic(tbltraining_topics topic);

        //List<tbltraining_topics> GetAllTopics();
        List<TopicModels> GetAllTopics();
    }
}
