namespace StudVoice.BLL.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MidlleName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleDTO Role { get; set; }
    }
}