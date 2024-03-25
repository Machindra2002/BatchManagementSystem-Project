using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BatchManagementSystem.Models
{
    public class Student_RegisterModel
    {
        public int student_id { get; set; }
        public string student_name { get; set; }
        public string gender { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public string profile_photo { get; set; }
        public string qualification { get; set; }
        public int registration_id { get; set; }
        public Nullable<int> course_id { get; set; }
        public Nullable<System.DateTime> registration_date { get; set; }
        public Nullable<double> discount { get; set; }
    }
}