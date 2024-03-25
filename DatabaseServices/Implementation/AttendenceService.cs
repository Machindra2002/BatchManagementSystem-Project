using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class AttendenceService:IAttendenceService
    {
        private IRepository<tblbatch> batchrepo;
        private IRepository<tblbatch_schedule> batchshedulerepo;
        private IRepository<tblschedule_attendance> attendencerepo;

        public AttendenceService(IRepository<tblbatch> batchrepo, IRepository<tblbatch_schedule> batchshedulerepo, IRepository<tblschedule_attendance> attendencerepo)
        {
            this.batchrepo = batchrepo;
            this.batchshedulerepo = batchshedulerepo;
            this.attendencerepo = attendencerepo;
        }

        public tblbatch GetBatchById(int batchId)
        {
            return batchrepo.GetById(batchId);
        }

        public List<tblbatch_schedule> GetBatchSheduleByBatchId(int batch_id)
        {
           return batchshedulerepo.GetAll().Where(b => b.batch_id==batch_id).ToList();
        }

        public void MarkStudentAttendence(tblschedule_attendance attendence)
        {
            attendencerepo.Create(attendence);
        }

        public void UpdateStudentBatchSchedule(tblbatch_schedule batchschedule)
        {
            batchshedulerepo.Update(batchschedule);
        }
    }
}
