using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class SectionExamServicio
    {
        private readonly MedexploraContext _context;
        public SectionExamServicio(MedexploraContext context) { _context = context; }

        public IEnumerable<SectionExamDTO> GetAll()
        {
            return _context.SectionExams.AsNoTracking().Select(MapToDTO).ToList();
        }

        public SectionExamDTO? GetById(int id)
        {
            var s = _context.SectionExams.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return s == null ? null : MapToDTO(s);
        }

        // Filtro útil: Obtener exámenes de una sección específica del cuerpo
        public IEnumerable<SectionExamDTO> GetBySectionId(int sectionId)
        {
            return _context.SectionExams
                .Where(x => x.SectionId == sectionId)
                .AsNoTracking()
                .Select(MapToDTO)
                .ToList();
        }

        public SectionExamDTO Create(SectionExamCreateDTO dto)
        {
            var nuevo = new SectionExam
            {
                SectionId = dto.SectionId,
                ExamTypeCode = dto.ExamTypeCode,
                TitleEs = dto.TitleEs,
                TitleEn = dto.TitleEn,
                SummaryEs = dto.SummaryEs,
                SummaryEn = dto.SummaryEn,
                SourceRef = dto.SourceRef
            };
            _context.SectionExams.Add(nuevo);
            _context.SaveChanges();
            return GetById(nuevo.Id)!;
        }

        public SectionExamDTO? Update(int id, SectionExamCreateDTO dto)
        {
            var s = _context.SectionExams.FirstOrDefault(x => x.Id == id);
            if (s == null) return null;

            s.SectionId = dto.SectionId;
            s.ExamTypeCode = dto.ExamTypeCode;
            s.TitleEs = dto.TitleEs;
            s.TitleEn = dto.TitleEn;
            s.SummaryEs = dto.SummaryEs;
            s.SummaryEn = dto.SummaryEn;
            s.SourceRef = dto.SourceRef;

            _context.SaveChanges();
            return GetById(id);
        }

        public bool Delete(int id)
        {
            var s = _context.SectionExams.FirstOrDefault(x => x.Id == id);
            if (s == null) return false;
            _context.SectionExams.Remove(s);
            _context.SaveChanges();
            return true;
        }

        private static SectionExamDTO MapToDTO(SectionExam s) => new SectionExamDTO
        {
            Id = s.Id,
            SectionId = s.SectionId,
            ExamTypeCode = s.ExamTypeCode,
            TitleEs = s.TitleEs,
            TitleEn = s.TitleEn,
            SummaryEs = s.SummaryEs,
            SummaryEn = s.SummaryEn,
            SourceRef = s.SourceRef
        };
    }
}