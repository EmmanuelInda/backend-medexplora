using MedExploraAPI.Models.DB;
using MedExploraAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class ExamStepServicio
    {
        private readonly MedexploraContext _context;

        public ExamStepServicio(MedexploraContext context)
        {
            _context = context;
        }

        public IEnumerable<ExamStepDTO> GetAll()
        {
            return _context.ExamSteps
                .AsNoTracking()
                .ToList()
                .Select(MapToDTO);
        }

        public ExamStepDTO? GetById(int id)
        {
            var entity = _context.ExamSteps
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);

            return entity == null ? null : MapToDTO(entity);
        }

        public ExamStepDTO Create(ExamStepCreateDTO dto)
        {
            var entity = new ExamStep
            {
                SectionExamId = dto.SectionExamId,
                StepOrder = dto.StepOrder,
                LabelEs = dto.LabelEs,
                DetailEs = dto.DetailEs,
                LabelEn = dto.LabelEn,
                DetailEn = dto.DetailEn
            };

            _context.ExamSteps.Add(entity);
            _context.SaveChanges();

            return MapToDTO(entity);
        }

        public bool Update(int id, ExamStepCreateDTO dto)
        {
            var entity = _context.ExamSteps.FirstOrDefault(e => e.Id == id);
            if (entity == null) return false;

            entity.SectionExamId = dto.SectionExamId;
            entity.StepOrder = dto.StepOrder;
            entity.LabelEs = dto.LabelEs;
            entity.DetailEs = dto.DetailEs;
            entity.LabelEn = dto.LabelEn;
            entity.DetailEn = dto.DetailEn;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.ExamSteps.FirstOrDefault(e => e.Id == id);
            if (entity == null) return false;

            _context.ExamSteps.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        private ExamStepDTO MapToDTO(ExamStep e)
        {
            return new ExamStepDTO
            {
                Id = e.Id,
                SectionExamId = e.SectionExamId,
                StepOrder = e.StepOrder,
                LabelEs = e.LabelEs,
                DetailEs = e.DetailEs,
                LabelEn = e.LabelEn,
                DetailEn = e.DetailEn
            };
        }
    }
}
