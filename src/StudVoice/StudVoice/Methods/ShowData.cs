using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudVoice.Methods
{
    static class ShowData
    {
        public static void Contacs()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var contacts = db.Contacts.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Contacts:");
                foreach (Contacts u in contacts)
                {
                    Console.WriteLine($"{u.Id} {u.Phone} {u.Email}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void Users()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Users:");
                foreach (Users u in users)
                {
                    Console.WriteLine($"{u.Id} {u.Name} {u.Surname} {u.MiddleName} {u.ContactId} {u.FacultyId}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void Faculties()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {

                var faculties = db.Faculties.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Faculties:");
                foreach (Faculties u in faculties)
                {
                    Console.WriteLine($"{u.Id} {u.Name}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void LessonFeedbacks()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {

                var lessonFeedbacks = db.LessonFeedbacks.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("LessonFeedbacks:");
                foreach (LessonFeedbacks u in lessonFeedbacks)
                {
                    Console.WriteLine($"{u.Id} {u.LessonId} {u.Feedback} {u.Point}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void Lessons()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var lessons = db.Lessons.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Lessons:");
                foreach (Lessons u in lessons)
                {
                    Console.WriteLine($"{u.Id} {u.TeacherId} {u.Name}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void Roles()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var roles = db.Roles.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Roles:");
                foreach (Roles u in roles)
                {
                    Console.WriteLine($"{u.Id} {u.Name}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void TeacherFeedbacks()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var teacherFeedbacks = db.TeacherFeedbacks.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("TeacherFeedbacks:");
                foreach (TeacherFeedbacks u in teacherFeedbacks)
                {
                    Console.WriteLine($"{u.Id} {u.TeacherId} {u.Feedback} {u.Point}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void Teachers()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var teachers = db.Teachers.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Teachers:");
                foreach (Teachers u in teachers)
                {
                    Console.WriteLine($"{u.Id} {u.UserId} {u.Name}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void UserRoles()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                var userRoles = db.UserRoles.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("UserRoles:");
                foreach (UserRoles u in userRoles)
                {
                    Console.WriteLine($"{u.Id} {u.UserId} {u.RoleId}");
                }
                Console.WriteLine("--------------------------");
            }
        }
        public static void ShowAllTables()
        {
            Users();
            Teachers();
            Faculties();
            Contacs();
            Roles();
            Lessons();
            LessonFeedbacks();
            TeacherFeedbacks();
            UserRoles();
        }
    }
}
