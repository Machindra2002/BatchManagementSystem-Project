using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface ITopicContentService
    {
        void AddContent(tbltopic_contents content);
        void UpdateContent(tbltopic_contents contents);
        void DeletTopicContent(int content_id);
        List<tbltopic_contents> GetContent();
        tbltopic_contents GetContentById(int content_id);
        List<tbltopic_contents> GetTopicWiseContent(int topic_id);

    }
}
