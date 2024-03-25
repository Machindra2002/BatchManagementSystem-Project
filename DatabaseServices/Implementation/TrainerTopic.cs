using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Implementation;
namespace DatabaseServices.Implementation
{
    public class TrainerTopic : ITrainerTopic
    {
        private IRepository<tbltrainer_topics> ttopic;
        public TrainerTopic(IRepository<tbltrainer_topics> ttopic)
        {
            this.ttopic = ttopic;
        }


        public void AddTopicWiseBatch(tbltrainer_topics trainertopic)
        {
            ttopic.Create(trainertopic);
        }
    }
}
