using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
using DatabaseServices.Interface;
namespace DatabaseServices.Implementation
{
    public class Trainers:ITrainers
    {
        private IRepository<tbltrainer> trainerrepo;
        private IRepository<tbltraining_topics> topicrepo;
        public Trainers(IRepository<tbltrainer> trainerrepo, IRepository<tbltraining_topics> topicrepo)
        {
            this.trainerrepo = trainerrepo;
            this.topicrepo = topicrepo;
        }

        public void AddTrainer(tbltrainer trainer)
        {
            trainerrepo.Create(trainer);
        }

        public void DeleteTrainer(int trainerId)
        {
            trainerrepo.Delete(trainerId);
        }

        public tbltrainer GetTrainerById(int trainerId)
        {
            return trainerrepo.GetById(trainerId);
        }

        public List<tbltrainer> GetTrainers()
        {
            return trainerrepo.GetAll();
        }

        public void UpadateTrainer(tbltrainer trainer)
        {
            trainerrepo.Update(trainer);
        }
    }
}
