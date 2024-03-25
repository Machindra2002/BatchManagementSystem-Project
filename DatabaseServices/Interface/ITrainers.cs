using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOperation;
namespace DatabaseServices.Interface
{
    public interface ITrainers
    {
        void AddTrainer(tbltrainer trainer);
        void UpadateTrainer(tbltrainer trainer);
        void DeleteTrainer(int trainerId);
        List<tbltrainer> GetTrainers();
        tbltrainer GetTrainerById(int trainerId);
    }
}
