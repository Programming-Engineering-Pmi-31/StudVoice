using System;
using System.Linq;

namespace StudVoice
{
    class Program
    {
        public static void FillTestData()
        {
            using (StudVoiceContext db = new StudVoiceContext())
            {
                #region Contacts
                db.Contacts.Add(new Contacts { Id = 1, Phone = "0934124123",Email="sdg@gmail.com" });
                db.Contacts.Add(new Contacts { Id = 2, Phone = "0831241241", Email = "sd12f@gmail.com" });
                db.Contacts.Add(new Contacts { Id = 3, Phone = "0914212412", Email = "sd32412g@gmail.com" });
                db.Contacts.Add(new Contacts { Id = 4, Phone = "0441241242", Email = "3425ffsf@gmail.com" });
                db.Contacts.Add(new Contacts { Id = 5, Phone = "0411241224", Email = "rweNem_321@gmail.com" });
                db.Contacts.Add(new Contacts { Id = 6, Phone = "0325423512", Email = "32rfNw@gmail.com" });
                #endregion

                #region Faculties
                db.Faculties.Add(new Faculties { Id = 4, Name= "Біологічний" });
                db.Faculties.Add(new Faculties { Id = 3, Name = "Іноземних мов" });
                db.Faculties.Add(new Faculties { Id = 5, Name = "Історичний" });
                db.Faculties.Add(new Faculties { Id = 2, Name = "Культури і мистецтв" });
                db.Faculties.Add(new Faculties { Id = 8, Name = "Міжнародних відносин" });
                db.Faculties.Add(new Faculties { Id = 7, Name = "Механіко - математичний" });
                db.Faculties.Add(new Faculties { Id = 6, Name = "Педагогічної освіти" });
                db.Faculties.Add(new Faculties { Id = 1, Name = "Прикладної математики та інформатики" });
                #endregion

                #region LessonFeedbacks
                db.LessonFeedbacks.Add(new LessonFeedbacks { Id = 1, LessonId = 1, Feedback = "feedback1", Point = 5 });
                db.LessonFeedbacks.Add(new LessonFeedbacks { Id = 2, LessonId = 2, Feedback = "feedback2", Point = 6 });
                db.LessonFeedbacks.Add(new LessonFeedbacks { Id = 3, LessonId = 3, Feedback = "feedback3", Point = 7 });
                db.LessonFeedbacks.Add(new LessonFeedbacks { Id = 4, LessonId = 2, Feedback = "feedback4", Point = 6 });
                db.LessonFeedbacks.Add(new LessonFeedbacks { Id = 5, LessonId = 4, Feedback = "feedback5", Point = 8 });
                db.LessonFeedbacks.Add(new LessonFeedbacks { Id = 6, LessonId = 4, Feedback = "feedback6", Point = 5 });
                #endregion

                #region Lessons
                db.Lessons.Add(new Lessons { Id = 1, TeacherId = 1, Name = "Lesson1" });
                db.Lessons.Add(new Lessons { Id = 2, TeacherId = 2, Name = "Lesson2" });
                db.Lessons.Add(new Lessons { Id = 3, TeacherId = 2, Name = "Lesson3" });
                db.Lessons.Add(new Lessons { Id = 4, TeacherId = 1, Name = "Lesson4" });
                #endregion

                #region Roles
                db.Roles.Add(new Roles { Id = "1", Name = "SuperAdmin" });
                db.Roles.Add(new Roles { Id = "2", Name = "Teacher" });
                db.Roles.Add(new Roles { Id = "3", Name = "Student" });
                #endregion

                #region TeacherFeedbacks
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 1, TeacherId = 1, Feedback = "feedback1", Point=5 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 2, TeacherId = 2, Feedback = "feedback2", Point = 5 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 3, TeacherId = 2, Feedback = "feedback3", Point = 6 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 4, TeacherId = 2, Feedback = "feedback4", Point = 7 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 5, TeacherId = 1, Feedback = "feedback5", Point = 2 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 6, TeacherId = 1, Feedback = "feedback6", Point = 4 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 7, TeacherId = 2, Feedback = "feedback7", Point = 7 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 8, TeacherId = 1, Feedback = "feedback8", Point = 10 });
                db.TeacherFeedbacks.Add(new TeacherFeedbacks { Id = 9, TeacherId = 1, Feedback = "feedback9", Point = 6 });
                #endregion

                #region Teachers
                db.Teachers.Add(new Teachers { Id = 1, UserId = "3", Name = "Teacher1" });
                db.Teachers.Add(new Teachers { Id = 2, UserId = "4", Name = "Teacher2" });
                #endregion

                #region UserRoles
                db.UserRoles.Add(new UserRoles { Id = "1", UserId = "1", RoleId="3"});
                db.UserRoles.Add(new UserRoles { Id = "2", UserId = "2", RoleId = "1" });
                db.UserRoles.Add(new UserRoles { Id = "3", UserId = "3", RoleId = "2" });
                db.UserRoles.Add(new UserRoles { Id = "4", UserId = "4", RoleId = "2" });
                db.UserRoles.Add(new UserRoles { Id = "5", UserId = "5", RoleId = "3" });
                db.UserRoles.Add(new UserRoles { Id = "6", UserId = "6", RoleId = "3" });
                #endregion

                #region Users
                db.Users.Add(new Users { Id = "1", Name = "Name1", Surname = "Surname1", MiddleName = "MiddleName1", ContactId = 1, FacultyId = 6 });
                db.Users.Add(new Users { Id = "2", Name = "Name2", Surname = "Surname2", ContactId = 2, FacultyId = 2 });
                db.Users.Add(new Users { Id = "3", Name = "Name3", Surname = "Surname3", MiddleName = "MiddleName3", ContactId = 3, FacultyId = 2 });
                db.Users.Add(new Users { Id = "4", Name = "Name4", Surname = "Surname4", MiddleName = "MiddleName4", ContactId = 4, FacultyId = 4 });
                db.Users.Add(new Users { Id = "5", Name = "Name5", Surname = "Surname5", ContactId = 5, FacultyId = 1 });
                db.Users.Add(new Users { Id = "6", Name = "Name6", Surname = "Surname6", ContactId = 6, FacultyId = 8 });
                #endregion

                db.SaveChanges();
            }
        }
        public static void ShowAllTables()
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

                var faculties = db.Faculties.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Faculties:");
                foreach (Faculties u in faculties)
                {
                    Console.WriteLine($"{u.Id} {u.Name}");
                }
                Console.WriteLine("--------------------------");

                var lessonFeedbacks = db.LessonFeedbacks.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("LessonFeedbacks:");
                foreach (LessonFeedbacks u in lessonFeedbacks)
                {
                    Console.WriteLine($"{u.Id} {u.LessonId} {u.Feedback} {u.Point}");
                }
                Console.WriteLine("--------------------------");

                var lessons = db.Lessons.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Lessons:");
                foreach (Lessons u in lessons)
                {
                    Console.WriteLine($"{u.Id} {u.TeacherId} {u.Name}");
                }
                Console.WriteLine("--------------------------");

                var roles = db.Roles.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Roles:");
                foreach (Roles u in roles)
                {
                    Console.WriteLine($"{u.Id} {u.Name}");
                }
                Console.WriteLine("--------------------------");

                var teacherFeedbacks = db.TeacherFeedbacks.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("TeacherFeedbacks:");
                foreach (TeacherFeedbacks u in teacherFeedbacks)
                {
                    Console.WriteLine($"{u.Id} {u.TeacherId} {u.Feedback} {u.Point}");
                }
                Console.WriteLine("--------------------------");

                var teachers = db.Teachers.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Teachers:");
                foreach (Teachers u in teachers)
                {
                    Console.WriteLine($"{u.Id} {u.UserId} {u.Name}");
                }
                Console.WriteLine("--------------------------");

                var userRoles = db.UserRoles.ToList();
                Console.WriteLine("--------------------------");
                Console.WriteLine("UserRoles:");
                foreach (UserRoles u in userRoles)
                {
                    Console.WriteLine($"{u.Id} {u.UserId} {u.RoleId}");
                }
                Console.WriteLine("--------------------------");

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
        static void Main(string[] args)
        {
            //FillTestData();
            ShowAllTables();
            Console.ReadKey();
        }
    }
}
