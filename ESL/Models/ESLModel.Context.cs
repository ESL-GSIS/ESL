﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ESLEntities : DbContext
    {
        public ESLEntities()
            : base("name=ESLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<Advisor> Advisors { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Counselor> Counselors { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<LangProficiencyLevel> LangProficiencyLevels { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Modification> Modifications { get; set; }
        public virtual DbSet<OverallProficiencyScale> OverallProficiencyScales { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolStudent> SchoolStudents { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAdvisor> StudentAdvisors { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<StudentCounselor> StudentCounselors { get; set; }
        public virtual DbSet<StudentLanguage> StudentLanguages { get; set; }
        public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }
        public virtual DbSet<Summary> Summaries { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherClass> TeacherClasses { get; set; }
    }
}