using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class TopicContentService : ITopicContentService
    {
        private IRepository<tbltopic_contents> contentrepo;
        private IRepository<tbltraining_topics> topicrepo;

        public TopicContentService(IRepository<tbltopic_contents> contentrepo, IRepository<tbltraining_topics> topicrepo)
        {
            this.contentrepo = contentrepo;
            this.topicrepo = topicrepo;
        }

        public void AddContent(tbltopic_contents content)
        {
            contentrepo.Create(content);
        }

        public void DeletTopicContent(int content_id)
        {
            contentrepo.Delete(content_id);
        }

        public List<tbltopic_contents> GetContent()
        {
            return contentrepo.GetAll();
        }

        public tbltopic_contents GetContentById(int content_id)
        {
            return contentrepo.GetById(content_id);
        }

        public List<tbltopic_contents> GetTopicWiseContent(int topic_id)
        {
            return contentrepo.GetAll().Where(e => e.topic_id.Equals(topic_id)).ToList();
        }

        public void UpdateContent(tbltopic_contents contents)
        {
            contentrepo.Update(contents);
        }
    }
}
