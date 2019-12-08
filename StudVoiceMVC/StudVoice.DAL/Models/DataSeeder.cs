using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StudVoice.DAL
{
    public static class DataSeeder
    {
        public static async Task SeedEssentialAsync(
            this IApplicationBuilder app,
            IServiceProvider services)
        {
            services.GetRequiredService<StudVoiceDBContext>().Database.Migrate();

            await app.SeedRolesAsync(services);
            await app.SeedUsersAsync(services);
        }

        public static async Task SeedAdditionalAsync(
            this IApplicationBuilder app,
            IServiceProvider services)
        {
            app.SeedData(services);
            await Task.CompletedTask;
        }

        public static async Task SeedRolesAsync(
            this IApplicationBuilder app,
            IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            await CreateIfNotExsits(roleManager, new Role() { Name = "Admin" });
            await CreateIfNotExsits(roleManager, new Role() { Name = "Teacher" });
            await CreateIfNotExsits(roleManager, new Role() { Name = "Student" });
        }

        public static async Task SeedUsersAsync(
            this IApplicationBuilder app,
            IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();

            var u1 = new User()
            {
                Id = "1",
                UserName = "TestTeacher1",
                Name = "Name1",
                Surname = "Surname1",
                MiddleName = "Teacherenko"
            };

            var u2 = new User()
            {
                Id = "2",
                UserName = "TestTeacher2",
                Name = "Name2",
                Surname = "Surname12",
                MiddleName = "Teacherovich"
            };

            var u3 = new User()
            {
                Id = "3",
                UserName = "TestTeacher3",
                Name = "Name3",
                Surname = "Surname3",
                MiddleName = "TeacherTeacher"
            };

            await SeedUserAsync(userManager, u1, "HelloWorld123@", "Teacher");
            await SeedUserAsync(userManager, u2, "HelloWorld123@", "Teacher");
            await SeedUserAsync(userManager, u3, "HelloWorld123@", "Teacher");

            var u4 = new User()
            {
                Id = "4",
                UserName = "TestStudent1",
                Name = "Name4",
                Surname = "Surname4",
                MiddleName = "Studentenko"
            };

            var u5 = new User()
            {
                Id = "5",
                UserName = "TestStudent2",
                Name = "Name5",
                Surname = "Surname5",
                MiddleName = "Studentovich"
            };

            var u6 = new User()
            {
                Id = "6",
                UserName = "TestStudent3",
                Name = "Name6",
                Surname = "Surname6",
                MiddleName = "StudentStudent"
            };

            await SeedUserAsync(userManager, u4, "HelloWorld123@", "Student");
            await SeedUserAsync(userManager, u5, "HelloWorld123@", "Student");
            await SeedUserAsync(userManager, u6, "HelloWorld123@", "Student");



        }

        public static void SeedData(this IApplicationBuilder app, IServiceProvider services)
        {
            var context = services.GetRequiredService<StudVoiceDBContext>();

            if (context.Contacts.Any()
                || context.Faculties.Any()
                || context.Lessons.Any()
                || context.LessonFeedbacks.Any()
                || context.Teachers.Any()
                || context.TeacherFeedbacks.Any())
            {
                return;
            }

            #region Faculties
            var f1 = new Faculty()
            {
                Id = 1,
                Name = "Культури і мистецтв",
            };
            var f2 = new Faculty()
            {
                Id = 2,
                Name = "Журналістики",
            };
            var f3 = new Faculty()
            {
                Id = 3,
                Name = "Прикладної математики та інформатики",
            };
            var f4 = new Faculty()
            {
                Id = 4,
                Name = "Історичний",
            };

            context.Faculties.AddRange(f1, f2, f3, f4);
            #endregion

            #region Contacts
            var c1 = new Contact() { Id = 1, Phone = "+1111111111", Email = "email1@com" };
            var c2 = new Contact() { Id = 2, Phone = "+2222222222", Email = "email2@com" };
            var c3 = new Contact() { Id = 3, Phone = "+3333333333", Email = "email3@com" };
            var c4 = new Contact() { Id = 4, Phone = "+4444444444", Email = "email4@com" };
            var c5 = new Contact() { Id = 5, Phone = "+5555555555", Email = "email5@com" };
            var c6 = new Contact() { Id = 6, Phone = "+6666666666", Email = "email6@com" };
            var c7 = new Contact() { Id = 7, Phone = "+7777777777", Email = "email7@com" };

            context.Contacts.AddRange(c1, c2, c3, c4, c5, c6, c7);
            #endregion

            #region Teachers
            context.Teachers.Add(new Teacher { Id = 1, UserId = "1", Name = "Teacher1" });
            context.Teachers.Add(new Teacher { Id = 2, UserId = "2", Name = "Teacher2" });
            context.Teachers.Add(new Teacher { Id = 3, UserId = "3", Name = "Teacher3" });
            #endregion

            #region TeacherFeedbacks
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 1, TeacherId = 1, Feedback = "feedback1", Point = 5 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 2, TeacherId = 2, Feedback = "feedback2", Point = 10 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 3, TeacherId = 2, Feedback = "feedback3", Point = 6 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 4, TeacherId = 3, Feedback = "feedback4", Point = 10 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 5, TeacherId = 1, Feedback = "feedback5", Point = 2 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 6, TeacherId = 3, Feedback = "feedback6", Point = 4 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 7, TeacherId = 2, Feedback = "feedback7", Point = 7 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 8, TeacherId = 1, Feedback = "feedback8", Point = 10 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 9, TeacherId = 1, Feedback = "feedback9", Point = 6 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 10, TeacherId = 3, Feedback = "feedback10", Point = 5 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 11, TeacherId = 1, Feedback = "feedback11", Point = 5 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 12, TeacherId = 2, Feedback = "feedback12", Point = 10 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 13, TeacherId = 3, Feedback = "feedback13", Point = 6 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 14, TeacherId = 2, Feedback = "feedback14", Point = 7 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 15, TeacherId = 3, Feedback = "feedback15", Point = 2 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 16, TeacherId = 1, Feedback = "feedback16", Point = 19 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 17, TeacherId = 3, Feedback = "feedback17", Point = 7 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 18, TeacherId = 1, Feedback = "feedback18", Point = 10 });
            context.TeacherFeedbacks.Add(new TeacherFeedback { Id = 19, TeacherId = 3, Feedback = "feedback19", Point = 6 });
            #endregion

            #region Lessons
            context.Lessons.Add(new Lesson { Theme = "Theme1", Id = 1, TeacherId = 1, Name = "Lesson1" });
            context.Lessons.Add(new Lesson { Theme = "Theme2", Id = 2, TeacherId = 2, Name = "Lesson2" });
            context.Lessons.Add(new Lesson { Theme = "Theme3", Id = 3, TeacherId = 3, Name = "Lesson3" });
            context.Lessons.Add(new Lesson { Theme = "Theme4", Id = 4, TeacherId = 1, Name = "Lesson4" });
            context.Lessons.Add(new Lesson { Theme = "Theme5", Id = 5, TeacherId = 2, Name = "Lesson5" });
            context.Lessons.Add(new Lesson { Theme = "Theme6", Id = 6, TeacherId = 3, Name = "Lesson6" });
            context.Lessons.Add(new Lesson { Theme = "Theme3", Id = 7, TeacherId = 1, Name = "Lesson7" });
            context.Lessons.Add(new Lesson { Theme = "Them2", Id = 8, TeacherId = 2, Name = "Lesson8" });
            context.Lessons.Add(new Lesson { Theme = "Theme2", Id = 9, TeacherId = 3, Name = "Lesson9" });
            context.Lessons.Add(new Lesson { Theme = "Theme1", Id = 10, TeacherId = 1, Name = "Lesson10" });
            context.Lessons.Add(new Lesson { Theme = "Theme2", Id = 11, TeacherId = 1, Name = "Lesson11" });
            context.Lessons.Add(new Lesson { Theme = "Theme6", Id = 12, TeacherId = 2, Name = "Lesson12" });
            context.Lessons.Add(new Lesson { Theme = "Theme7", Id = 13, TeacherId = 3, Name = "Lesson13" });
            context.Lessons.Add(new Lesson { Theme = "Theme8", Id = 14, TeacherId = 1, Name = "Lesson14" });
            context.Lessons.Add(new Lesson { Theme = "Theme9", Id = 15, TeacherId = 2, Name = "Lesson15" });
            context.Lessons.Add(new Lesson { Theme = "Theme10", Id = 16, TeacherId = 1, Name = "Lesson16" });
            context.Lessons.Add(new Lesson { Theme = "Theme11", Id = 17, TeacherId = 1, Name = "Lesson17" });
            context.Lessons.Add(new Lesson { Theme = "Theme1", Id = 18, TeacherId = 2, Name = "Lesson18" });
            context.Lessons.Add(new Lesson { Theme = "Theme12", Id = 19, TeacherId = 3, Name = "Lesson19" });
            #endregion

            #region LessonFeedbacks
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 1, LessonId = 1, Feedback = "feedback1", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 2, LessonId = 1, Feedback = "feedback2", Point = 2 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 3, LessonId = 1, Feedback = "feedback3", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 4, LessonId = 2, Feedback = "feedback4", Point = 6 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 5, LessonId = 4, Feedback = "feedback5", Point = 10 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 6, LessonId = 4, Feedback = "feedback6", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 7, LessonId = 3, Feedback = "feedback7", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 8, LessonId = 4, Feedback = "feedback8", Point = 3 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 9, LessonId = 6, Feedback = "feedback9", Point = 8 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 10, LessonId = 7, Feedback = "feedback10", Point = 4 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 11, LessonId = 7, Feedback = "feedback11", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 12, LessonId = 7, Feedback = "feedback12", Point = 2 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 13, LessonId = 7, Feedback = "feedback13", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 14, LessonId = 18, Feedback = "feedback14", Point = 6 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 15, LessonId = 19, Feedback = "feedback15", Point = 10 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 16, LessonId = 11, Feedback = "feedback16", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 17, LessonId = 11, Feedback = "feedback17", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 18, LessonId = 1, Feedback = "feedback18", Point = 3 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 19, LessonId = 1, Feedback = "feedback19", Point = 8 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 20, LessonId = 2, Feedback = "feedback20", Point = 4 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 21, LessonId = 3, Feedback = "feedback21", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 22, LessonId = 4, Feedback = "feedback22", Point = 2 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 23, LessonId = 5, Feedback = "feedback23", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 24, LessonId = 6, Feedback = "feedback24", Point = 6 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 25, LessonId = 7, Feedback = "feedback25", Point = 10 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 26, LessonId = 8, Feedback = "feedback26", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 27, LessonId = 9, Feedback = "feedback27", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 28, LessonId = 10, Feedback = "feedback28", Point = 3 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 29, LessonId = 11, Feedback = "feedback29", Point = 8 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 30, LessonId = 12, Feedback = "feedback30", Point = 4 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 31, LessonId = 13, Feedback = "feedback31", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 32, LessonId = 14, Feedback = "feedback32", Point = 2 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 33, LessonId = 15, Feedback = "feedback33", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 34, LessonId = 16, Feedback = "feedback34", Point = 6 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 35, LessonId = 17, Feedback = "feedback35", Point = 10 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 36, LessonId = 18, Feedback = "feedback36", Point = 5 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 37, LessonId = 19, Feedback = "feedback37", Point = 7 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 38, LessonId = 2, Feedback = "feedback38", Point = 3 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 39, LessonId = 5, Feedback = "feedback39", Point = 8 });
            context.LessonFeedbacks.Add(new LessonFeedback { Id = 40, LessonId = 7, Feedback = "feedback40", Point = 4 });
            #endregion

            context.SaveChanges();
        }

        private static async Task SeedUserAsync(
            UserManager<User> userManager,
            User user,
            string password,
            string role)
        {
            if (await userManager.FindByNameAsync(user.UserName) == null)
            {
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        private static async Task CreateIfNotExsits(
            RoleManager<Role> roleManager,
            Role role)
        {
            if (await roleManager.FindByNameAsync(role.Name) == null)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}