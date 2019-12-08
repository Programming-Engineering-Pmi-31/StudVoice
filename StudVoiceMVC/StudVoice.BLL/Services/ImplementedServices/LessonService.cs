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
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LessonService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<LessonDTO> CreateAsync(LessonDTO dto)
        {
            try
            {
                Lesson lesson = _mapper.Map<Lesson>(dto);
                var res = await _unitOfWork.LessonRepository.AddAsync(lesson);
                return _mapper.Map<LessonDTO>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            Lesson lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            await _unitOfWork.LessonRepository.RemoveAsync(lesson);
        }

        public async Task<LessonDTO> GetAsync(int id)
        {
            return _mapper.Map<LessonDTO>(await _unitOfWork.LessonRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<LessonDTO>> GetRangeAsync(uint offset, uint amount)
        {
            List<Lesson> source = await _unitOfWork.LessonRepository.GetRangeAsync(offset, amount);
            List<LessonDTO> res = new List<LessonDTO>();
            source.ForEach(x => res.Add(_mapper.Map<LessonDTO>(x)));
            return res;
        }

        public Task<IEnumerable<LessonDTO>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<LessonDTO> UpdateAsync(LessonDTO dto)
        {
            Lesson lesson = _mapper.Map<Lesson>(dto);
            _unitOfWork.LessonRepository.Update(lesson);
            return _mapper.Map<LessonDTO>(await _unitOfWork.TeacherRepository.GetByIdAsync(lesson.Id));
        }
    }
}
