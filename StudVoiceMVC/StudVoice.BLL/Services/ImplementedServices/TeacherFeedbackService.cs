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
    class TeacherFeedbackService:ITeacherFeedbackService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TeacherFeedbackService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TeacherFeedbackDTO> CreateAsync(TeacherFeedbackDTO dto)
        {
            try
            {
                TeacherFeedback teacherFeedback = _mapper.Map<TeacherFeedback>(dto);
                var res = await _unitOfWork.TeacherFeedbackRepository.AddAsync(teacherFeedback);
                return _mapper.Map<TeacherFeedback, TeacherFeedbackDTO>(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            TeacherFeedback teacherFeedback = await _unitOfWork.TeacherFeedbackRepository.GetByIdAsync(id);
            await _unitOfWork.TeacherFeedbackRepository.RemoveAsync(teacherFeedback);
        }

        public async Task<TeacherFeedbackDTO> GetAsync(int id)
        {
            var res = await _unitOfWork.TeacherFeedbackRepository.GetByIdAsync(id);
            return _mapper.Map<TeacherFeedback, TeacherFeedbackDTO>(res);
        }

        public async Task<IEnumerable<TeacherFeedbackDTO>> GetRangeAsync(uint offset, uint amount)
        {
            List<TeacherFeedback> source = await _unitOfWork.TeacherFeedbackRepository.GetRangeAsync(offset, amount);
            List<TeacherFeedbackDTO> res = new List<TeacherFeedbackDTO>();
            source.ForEach(x => res.Add(_mapper.Map<TeacherFeedback, TeacherFeedbackDTO>(x)));
            return res;
        }

        public Task<IEnumerable<TeacherFeedbackDTO>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<TeacherFeedbackDTO> UpdateAsync(TeacherFeedbackDTO dto)
        {
            TeacherFeedback teacherFeedback = _mapper.Map<TeacherFeedback>(dto);
            _unitOfWork.TeacherFeedbackRepository.Update(teacherFeedback);
            return _mapper.Map<TeacherFeedback, TeacherFeedbackDTO>(await _unitOfWork.TeacherFeedbackRepository.GetByIdAsync(teacherFeedback.Id));
        }
    }
}
