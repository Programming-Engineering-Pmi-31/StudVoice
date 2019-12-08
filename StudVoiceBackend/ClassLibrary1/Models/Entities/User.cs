using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using StudVoice.DAL.Models.Entities.Abstractions;


namespace StudVoice.DAL
{
    public  class User : IdentityUser, IAuditableEntity
    {
        public User()
        {
            Teachers = new HashSet<Teacher>();
            UserRoles = new HashSet<UserRole>();

            ContactCreate = new HashSet<Contact>();
            ContactMod = new HashSet<Contact>();
            FacultyCreate = new HashSet<Faculty>();
            FacultyMod = new HashSet<Faculty>();
            LessonCreate = new HashSet<Lesson>();
            LessonMod = new HashSet<Lesson>();
            LessonFeedbackCreate = new HashSet<LessonFeedback>();
            LessonFeedbackMod = new HashSet<LessonFeedback>();
            TeacherCreate = new HashSet<Teacher>();
            TeacherMod = new HashSet<Teacher>();
            TeacherFeedbackCreate = new HashSet<TeacherFeedback>();
            TeacherFeedbackMod = new HashSet<TeacherFeedback>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int? ContactId { get; set; }
        public int? FacultyId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Contact> ContactCreate { get; set; }
        public virtual ICollection<Contact> ContactMod { get; set; }
        public virtual ICollection<Faculty> FacultyCreate { get; set; }
        public virtual ICollection<Faculty> FacultyMod { get; set; }
        public virtual ICollection<Lesson> LessonCreate { get; set; }
        public virtual ICollection<Lesson> LessonMod { get; set; }
        public virtual ICollection<LessonFeedback> LessonFeedbackCreate { get; set; }
        public virtual ICollection<LessonFeedback> LessonFeedbackMod { get; set; }
        public virtual ICollection<Teacher> TeacherCreate { get; set; }
        public virtual ICollection<Teacher> TeacherMod { get; set; }
        public virtual ICollection<TeacherFeedback> TeacherFeedbackCreate { get; set; }
        public virtual ICollection<TeacherFeedback> TeacherFeedbackMod { get; set; }
    }
}
