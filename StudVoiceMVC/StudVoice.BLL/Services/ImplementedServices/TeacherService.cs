using AutoMapper;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Services.Interfaces;
using StudVoice.DAL;
using StudVoice.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudVoice.BLL.Services.ImplementedServices
{
    public class TeacherService : ITeacherService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TeacherDTO> CreateAsync(TeacherDTO dto)
        {
            try
            {
                Teacher teacher = _mapper.Map<Teacher>(dto);
                var res = await _unitOfWork.TeacherRepository.AddAsync(teacher);
                return _mapper.Map<Teacher,TeacherDTO>(res);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            Teacher teacher = await _unitOfWork.TeacherRepository.GetByIdAsync(id);
            await _unitOfWork.TeacherRepository.RemoveAsync(teacher);
        }

        public async Task<TeacherDTO> GetAsync(int id)
        {
            var res = await _unitOfWork.TeacherRepository.GetByIdAsync(id);
            return _mapper.Map<Teacher,TeacherDTO>(res);
        }

        public async Task<TeacherDTO> GetAsyncName(string name)
        {
            var res = await _unitOfWork.TeacherRepository.GetAllAsync();
            var rr = res.Find(x => x.Name == name);
            return _mapper.Map<Teacher, TeacherDTO>(rr);
        }

        public async Task<TeacherDTO> GetAsyncNameAsync(string name)
        {
            var res = await _unitOfWork.TeacherRepository.GetAllAsync();
            var rr = res.Find(x => x.Name == name);
            return _mapper.Map<Teacher, TeacherDTO>(rr);
        }

        public async Task<IEnumerable<TeacherDTO>> GetRangeAsync(uint offset, uint amount)
        {
            List<Teacher> source = await _unitOfWork.TeacherRepository.GetRangeAsync(offset, amount);
            List<TeacherDTO> res = new List<TeacherDTO>();
            source.ForEach(x => res.Add(_mapper.Map<Teacher,TeacherDTO>(x)));
            return res;
        }

        public Task<IEnumerable<TeacherDTO>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<TeacherDTO> UpdateAsync(TeacherDTO dto)
        {
            Teacher teacher = _mapper.Map<Teacher>(dto);
            _unitOfWork.TeacherRepository.Update(teacher);
            return _mapper.Map<Teacher,TeacherDTO>(await _unitOfWork.TeacherRepository.GetByIdAsync(teacher.Id));
        }
    }
}
