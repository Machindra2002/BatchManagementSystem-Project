using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface IBatchStudentService
    {
        void AddStudentBatch(tblbatch_students batchstudent);
        void UpdateStudentBatch(tblbatch_students batchstudent);
        void DeleteStudentBatch(int studentbatchId);

        //List<tblstudent_registrations> GetTopicWiseStudent(int topic_id, int student_id);
    }
}
