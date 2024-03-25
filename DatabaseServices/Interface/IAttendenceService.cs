using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface IAttendenceService
    {
        tblbatch GetBatchById(int batchId);
        List<tblbatch_schedule> GetBatchSheduleByBatchId(int batch_id);
        void MarkStudentAttendence(tblschedule_attendance attendence);
        void UpdateStudentBatchSchedule(tblbatch_schedule batchschedule);
    }
}
