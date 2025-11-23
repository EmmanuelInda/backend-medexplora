using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class ExamTypeServicio
    {
        private readonly MedexploraContext _context;
        public ExamTypeServicio(MedexploraContext context) { _context = context; }

        public IEnumerable<ExamTypeDTO> GetAll()
        {
            return _context.ExamTypes.AsNoTracking().Select(e => new ExamTypeDTO
            {
                Code = e.Code,
                NameEs = e.NameEs,
                NameEn = e.NameEn,
                SortOrder = e.SortOrder
            }).ToList();
        }

        public ExamTypeDTO? GetByCode(string code)
        {
            var e = _context.ExamTypes.AsNoTracking().FirstOrDefault(x => x.Code == code);
            return e == null ? null : new ExamTypeDTO
            {
                Code = e.Code,
                NameEs = e.NameEs,
                NameEn = e.NameEn,
                SortOrder = e.SortOrder
            };
        }

        public ExamTypeDTO Create(ExamTypeCreateDTO dto)
        {
            var nuevo = new ExamType
            {
                Code = dto.Code,
                NameEs = dto.NameEs,
                NameEn = dto.NameEn,
                SortOrder = dto.SortOrder ?? 0
            };
            _context.ExamTypes.Add(nuevo);
            _context.SaveChanges();
            return GetByCode(nuevo.Code)!;
        }

        public ExamTypeDTO? Update(string code, ExamTypeCreateDTO dto)
        {
            var e = _context.ExamTypes.FirstOrDefault(x => x.Code == code);
            if (e == null) return null;

            e.NameEs = dto.NameEs;
            e.NameEn = dto.NameEn;
            e.SortOrder = dto.SortOrder;

            _context.SaveChanges();
            return GetByCode(code);
        }

        public bool Delete(string code)
        {
            var e = _context.ExamTypes.FirstOrDefault(x => x.Code == code);
            if (e == null) return false;
            _context.ExamTypes.Remove(e);
            _context.SaveChanges();
            return true;
        }
    }
}