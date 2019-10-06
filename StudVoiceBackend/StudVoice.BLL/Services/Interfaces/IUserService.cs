using System.Collections.Generic;
using System.Threading.Tasks;
using StudVoice.BLL.DTOs;

namespace StudVoice.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> UpdatePasswordAsync(UserDTO user, string newPassword);
        Task<IEnumerable<UserDTO>> GetAssignees(uint offset, uint amount);
        Task<UserDTO> GetAsync(string id);
        Task<IEnumerable<UserDTO>> GetRangeAsync(uint offset, uint amount);
        Task<UserDTO> CreateAsync(UserDTO value);
        Task<UserDTO> UpdateAsync(UserDTO value);
        Task DeleteAsync(string id);
        Task<IEnumerable<RoleDTO>> GetRoles();
        void UpdateCurrentUserId(string newValue);
        string GetCurrentUserId();
    }
}