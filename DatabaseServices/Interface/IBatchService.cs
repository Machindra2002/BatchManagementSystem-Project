using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices;
using DatabaseServices.Models;

namespace DatabaseServices.Interface
{
    public interface IBatchService
    {
        void CreateBatch(tblbatch batch);
        void AddStudentToBatch(int batchId, int registrationId);
        void DeleteBatch(int batch_id);
        void UpdateBatch(tblbatch batch);
        List<tblbatch> GetAllBatches();
        tblbatch GetBatch(int batch_id);
        List<TopicWiseStudentModel> TopicWiseStudent(int topic_id);
    }
}
