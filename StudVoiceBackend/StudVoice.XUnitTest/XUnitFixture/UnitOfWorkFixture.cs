using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudVoice.DAL;
using StudVoice.DAL.Repositories.ImplementedRepositories;
using StudVoice.DAL.UnitOfWork;
using Moq;
using StudVoice.XUnitTest.Helper;

namespace StudVoice.XUnitTest
{
    public class UnitOfWorkFixture : IDisposable
    {
        private class UserStore : UserStore<User, Role, StudVoiceDBContext, string, IdentityUserClaim<string>,
            UserRole, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>
        {
            public UserStore(StudVoiceDBContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }
        }

        private class RoleStore : RoleStore<Role, StudVoiceDBContext, string, UserRole, IdentityRoleClaim<string>>
        {
            public RoleStore(StudVoiceDBContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }
        }

        /// <summary>
        /// Creates a <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <returns>A new object each time.</returns>
        public IUnitOfWork CreateMockUnitOfWork()
        {
            StudVoiceDBContext transITDBContext = new StudVoiceDBContext(
                new DbContextOptionsBuilder<StudVoiceDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .EnableSensitiveDataLogging()
                    .Options
            );

            IUserStore<User> userStore = new UserStore(transITDBContext);
            IRoleStore<Role> roleStore = new RoleStore(transITDBContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(RoleManager<Role>))).Returns(MockHelpers.TestRoleManager(roleStore));
            serviceProvider.Setup(x => x.GetService(typeof(UserManager<User>))).Returns(MockHelpers.TestUserManager(userStore));

            var unitOfWork = new UnitOfWork(transITDBContext, serviceProvider.Object);

            unitOfWork.RoleManager.CreateAsync(new Role { Name = "STUDENT"}).Wait();
            unitOfWork.RoleManager.CreateAsync(new Role { Name = "TEACHER"}).Wait();

            return unitOfWork;
        }

        public void Dispose()
        {
        }
    }
}
