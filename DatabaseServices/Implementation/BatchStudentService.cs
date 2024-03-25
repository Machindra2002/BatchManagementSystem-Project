using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class BatchStudentService : IBatchStudentService
    {
        private IRepository<tblbatch_students> batchstudentrepo;
        public BatchStudentService(IRepository<tblbatch_students> batchstudentrepo)
        {
            this.batchstudentrepo = batchstudentrepo;
        }

        public void AddStudentBatch(tblbatch_students batchstudent)
        {
            batchstudentrepo.Create(batchstudent);
        }

        public void DeleteStudentBatch(int studentbatchId)
        {
            batchstudentrepo.Delete(studentbatchId);
        }

        public void UpdateStudentBatch(tblbatch_students batchstudent)
        {
            batchstudentrepo.Update(batchstudent);
        }
    }
}
