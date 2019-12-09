using StudVoice.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudVoice.BLL.Services.Interfaces
{
    public interface ITeacherService : ICrudService<TeacherDTO>
    {
        Task<TeacherDTO> GetAsyncNameAsync(string name);
    }
}
