﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseOperation
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class batch_managementDBEntities : DbContext
    {
        public batch_managementDBEntities()
            : base("name=batch_managementDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbladmin_details> tbladmin_details { get; set; }
        public virtual DbSet<tblbatch_schedule> tblbatch_schedule { get; set; }
        public virtual DbSet<tblbatch_schedule_attendance> tblbatch_schedule_attendance { get; set; }
        public virtual DbSet<tblbatch_students> tblbatch_students { get; set; }
        public virtual DbSet<tblbatch> tblbatches { get; set; }
        public virtual DbSet<tblschedule_attendance> tblschedule_attendance { get; set; }
        public virtual DbSet<tblstudent_details> tblstudent_details { get; set; }
        public virtual DbSet<tblstudent_payments> tblstudent_payments { get; set; }
        public virtual DbSet<tblstudent_registrations> tblstudent_registrations { get; set; }
        public virtual DbSet<tbltopic_contents> tbltopic_contents { get; set; }
        public virtual DbSet<tbltrainer_topics> tbltrainer_topics { get; set; }
        public virtual DbSet<tbltrainer> tbltrainers { get; set; }
        public virtual DbSet<tbltraining_course_fees> tbltraining_course_fees { get; set; }
        public virtual DbSet<tbltraining_courses> tbltraining_courses { get; set; }
        public virtual DbSet<tbltraining_topics> tbltraining_topics { get; set; }
        public virtual DbSet<tblcourse_topics> tblcourse_topics { get; set; }
    }
}
