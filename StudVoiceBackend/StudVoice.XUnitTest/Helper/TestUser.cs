using StudVoice.BLL.DTOs;

namespace StudVoice.XUnitTest.Helper
{
    public class TestUser : UserDTO
    {
        public TestUser()
        {
            Id = "1";
            UserName = "testStudent";
            Password = "HelloWorld123@";
            Name = "Vitalii";
            MiddleName = "Olegovich";
            Surname = "Maksymiv";
            Role = new RoleDTO
            {
                Name = "STUDENT"
            };
        }
    }
}