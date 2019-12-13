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
    public class LessonFeedbackService:ILessonFeedbackService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LessonFeedbackService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<LessonFeedbackDTO> CreateAsync(LessonFeedbackDTO dto)
        {
            try
            {
                LessonFeedback lessonFeedback = _mapper.Map<LessonFeedback>(dto);
                var res = await _unitOfWork.LessonFeedbackRepository.AddAsync(lessonFeedback);
                return _mapper.Map<LessonFeedback, LessonFeedbackDTO>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            LessonFeedback lessonFeedback = await _unitOfWork.LessonFeedbackRepository.GetByIdAsync(id);
            await _unitOfWork.LessonFeedbackRepository.RemoveAsync(lessonFeedback);
        }

        public async Task<LessonFeedbackDTO> GetAsync(int id)
        {
            var res = await _unitOfWork.LessonFeedbackRepository.GetByIdAsync(id);
            return _mapper.Map<LessonFeedback, LessonFeedbackDTO>(res);
        }

        public async Task<IEnumerable<LessonFeedbackDTO>> GetRangeAsync(uint offset, uint amount)
        {
            List<LessonFeedback> source = await _unitOfWork.LessonFeedbackRepository.GetRangeAsync(offset, amount);
            List<LessonFeedbackDTO> res = new List<LessonFeedbackDTO>();
            source.ForEach(x => res.Add(_mapper.Map<LessonFeedback, LessonFeedbackDTO>(x)));
            return res;
        }

        public Task<IEnumerable<LessonFeedbackDTO>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<LessonFeedbackDTO> UpdateAsync(LessonFeedbackDTO dto)
        {
            LessonFeedback lessonFeedback = _mapper.Map<LessonFeedback>(dto);
            _unitOfWork.LessonFeedbackRepository.Update(lessonFeedback);
            return _mapper.Map<LessonFeedback, LessonFeedbackDTO>(await _unitOfWork.LessonFeedbackRepository.GetByIdAsync(lessonFeedback.Id));
        }
    }
}
