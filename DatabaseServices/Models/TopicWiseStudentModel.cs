using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServices.Models
{
    public class TopicWiseStudentModel
    {
        public int student_id { get; set; }
        public int resgitration_id { get; set; }
        public string student_name { get; set; }
        public string course_name { get; set; }
    }

    //public class student
    //{
    //    public int registration_id { get; set; }
    //    public bool is_selected { get; set; }
    //}
}
