using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
using DatabaseServices.Models;

namespace DatabaseServices.Implementation
{
    public class BatchService:IBatchService
    {
        private IRepository<tblbatch> batchrepo;
        private IRepository<tblbatch_students> studentbatchrepo;
        private IRepository<tblstudent_registrations> studentregisterrepo;
        private IRepository<tblstudent_details> studentrepo;
        private IRepository<tbltraining_courses> courserepo;
        private IRepository<tblcourse_topics> courseTopicRepo;
        private IRepository<tbltraining_topics> topicRepo;
        public BatchService(IRepository<tblbatch> batchrepo, IRepository<tbltraining_topics> topicRepo, IRepository<tblcourse_topics> courseTopicRepo, IRepository<tbltraining_courses> courserepo, IRepository<tblstudent_details> studentrepo, IRepository<tblbatch_students> studentbatchrepo, IRepository<tblstudent_registrations> studentregisterrepo)
        {
            this.batchrepo = batchrepo;
            this.studentbatchrepo = studentbatchrepo;
            this.courseTopicRepo = courseTopicRepo;
            this.studentregisterrepo = studentregisterrepo;
            this.topicRepo=topicRepo;
            this.courserepo=courserepo;
            this.studentrepo = studentrepo;
        }

        public void CreateBatch(tblbatch batch)
        {
            batchrepo.Create(batch);
        }
        public void UpdateBatch(tblbatch batch)
        {
            batchrepo.Update(batch);
        }
        public void AddStudentToBatch(int batchId, int registrationId)
        {
            tblbatch_students student = new tblbatch_students
            {
                batch_id = batchId,
                registration_id = registrationId
            };
            studentbatchrepo.Create(student);
        }
        public void DeleteBatch(int batch_id)
        {
            batchrepo.Delete(batch_id);
        }

        public List<tblbatch> GetAllBatches()
        {
            return batchrepo.GetAll();
        }

        public tblbatch GetBatch(int batch_id)
        {
            return batchrepo.GetById(batch_id);
        }

        public List<TopicWiseStudentModel> TopicWiseStudent(int topic_id)
        {
            List<TopicWiseStudentModel>lst=new List<TopicWiseStudentModel>();
            var query = from sr in studentregisterrepo.GetAll()
                        join s in studentrepo.GetAll() on sr.student_id equals s.student_id
                        join c in courserepo.GetAll() on sr.course_id equals c.course_id
                        join ct in courseTopicRepo.GetAll() on c.course_id equals ct.course_id
                        join t in topicRepo.GetAll() on ct.topic_id equals t.topic_id
                        where t.topic_id == topic_id
                        select new
                        {
                            studentId = s.student_id,
                            registerId = sr.registration_id,
                            courseName = c.course_name,
                            studentName = s.student_name
                        };
            foreach(var q in query)
            {
                TopicWiseStudentModel ts=new TopicWiseStudentModel()
                {
                    student_id=q.studentId,
                    student_name=q.studentName,
                    course_name=q.courseName,
                    resgitration_id=q.registerId
                };
                lst.Add(ts);
            }
            return lst;
        }
    }
}
