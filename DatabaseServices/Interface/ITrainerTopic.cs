using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;

namespace DatabaseServices.Interface
{
    public interface ITrainerTopic
    {
        void AddTopicWiseBatch(tbltrainer_topics trainertopic);

    }
}
