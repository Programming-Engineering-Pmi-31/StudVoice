using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudVoice.BLL.Comparers;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Services.ImplementedServices;
using StudVoice.XUnitTest.Helper;
using Xunit;

namespace StudVoice.XUnitTest.ServiceTest
{
    public class UserServiceTests : IClassFixture<UnitOfWorkFixture>, IClassFixture<MapperFixture>
    {
        private readonly UnitOfWorkFixture _fixture;
        private readonly MapperFixture _mapperFixture;

        public UserServiceTests(UnitOfWorkFixture unitOfWorkFixture, MapperFixture mapperFixture)
        {
            _fixture = unitOfWorkFixture;
            _mapperFixture = mapperFixture;
        }

        [Fact]
        public async Task UserService_Should_Get_Single_User()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            // Act
            var result = await userService.CreateAsync(new TestUser());
            // Assert
            Assert.Equal(new TestUser(), result, new UserComparer());
        }

        [Fact]
        public async Task UserService_Should_Get_Range_Users()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            var users = new TestUser[] {
                new TestUser
                {UserName = "testStudent",
                    Role = new RoleDTO
                    {
                    Name = "STUDENT"}
                },
                new TestUser {Id="2", UserName = "testStudent"}
            };
            // Act
            foreach (UserDTO user in users)
            {
                await userService.CreateAsync(user);
            }

            var list = await userService.GetRangeAsync(0, 100);
            // Assert
            Assert.True(list.OrderBy(u => u.Name).SequenceEqual(users, new UserComparer()));
        }

        [Fact]
        public async Task UserService_Should_Update_Password()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            var value = new TestUser
            {
                UserName = "testStudent",
                Password = "AbagfgA122@2"
            };
            // Act
            var actual = await userService.UpdatePasswordAsync(
                await userService.CreateAsync(value), "HelloWorld123@"
            );
            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task UserService_Should_Get_Assignees()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            var users = new List<UserDTO>
            {
                new TestUser
                { Id = "1", UserName = "testStudent1", Role = new RoleDTO
                    {
                    Name = "TEACHER" }
                },
                new TestUser
                { Id = "2", UserName = "testStudent2", Role = new RoleDTO
                    {
                    Name = "TEACHER" }
                }
            };
            var assigned = new List<UserDTO> {
                new TestUser {Id = "3", UserName = "test1" },
                new TestUser {Id = "4", UserName = "test2" }
            };
            users.AddRange(assigned);

            // Act
            foreach (UserDTO user in users)
            {
                await userService.CreateAsync(user);
            }

            var list = await userService.GetStudents(0, 100);
            // Assert
            Assert.True(list.OrderBy(u => u.Id).SequenceEqual(assigned, new UserComparer()));
        }

        [Fact]
        public async Task UserService_Should_Update_User()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            // Act
            var result = await userService.CreateAsync(new TestUser());
            result.Name = "Vitalii";
            result.Surname = "Maksymiv";
            result.UserName = "testStudent";
            var updated = await userService.UpdateAsync(result);
            // Assert
            Assert.Equal(result, updated, new UserComparer());
        }

        [Fact]
        public async Task UserService_Should_Create_User()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            // Act
            var result = await userService.CreateAsync(new TestUser());
            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Role);
            Assert.NotEqual(result.Id, default(Guid).ToString());
        }

        [Fact]
        public async Task UserService_Should_Delete_User()
        {
            // Arrange
            var unitOfWork = _fixture.CreateMockUnitOfWork();
            var userService = new UserService(_mapperFixture.Mapper, unitOfWork);
            // Act
            var result = await userService.CreateAsync(new TestUser());
            await userService.DeleteAsync(result.Id);
            // Assert
            Assert.Null(await userService.GetAsync(result.Id));
        }
    }
}