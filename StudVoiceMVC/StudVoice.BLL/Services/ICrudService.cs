using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudVoice.BLL.Services
{
    public interface ICrudService<TEntityDTO> where TEntityDTO : class, new()
    {
        Task<TEntityDTO> GetAsync(int id);

        Task<IEnumerable<TEntityDTO>> GetRangeAsync(uint offset, uint amount);

        Task<TEntityDTO> CreateAsync(TEntityDTO dto);

        Task<TEntityDTO> UpdateAsync(TEntityDTO dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<TEntityDTO>> SearchAsync(string search);
    }
}