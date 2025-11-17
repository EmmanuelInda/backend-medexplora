using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB; // Ojo: System de .NET puede chocar con tu modelo System. Usa alias si pasa.
using Microsoft.EntityFrameworkCore;
using DBSystem = MedExploraAPI.Models.DB.System; // Alias para evitar conflicto

namespace MedExploraAPI.Servicio
{
    public class SystemServicio
    {
        private readonly MedexploraContext _context;
        public SystemServicio(MedexploraContext context) { _context = context; }

        public IEnumerable<SystemDTO> GetAll()
        {
            return _context.Systems.AsNoTracking().Select(s => new SystemDTO
            {
                Code = s.Code,
                NameEs = s.NameEs,
                NameEn = s.NameEn
            }).ToList();
        }

        public SystemDTO? GetByCode(string code)
        {
            var s = _context.Systems.AsNoTracking().FirstOrDefault(x => x.Code == code);
            return s == null ? null : new SystemDTO { Code = s.Code, NameEs = s.NameEs, NameEn = s.NameEn };
        }

        public SystemDTO Create(SystemCreateDTO dto)
        {
            var nuevo = new DBSystem { Code = dto.Code, NameEs = dto.NameEs, NameEn = dto.NameEn };
            _context.Systems.Add(nuevo);
            _context.SaveChanges();
            return GetByCode(nuevo.Code)!;
        }

        public SystemDTO? Update(string code, SystemCreateDTO dto)
        {
            var s = _context.Systems.FirstOrDefault(x => x.Code == code);
            if (s == null) return null;
            s.NameEs = dto.NameEs;
            s.NameEn = dto.NameEn;
            _context.SaveChanges();
            return GetByCode(code);
        }

        public bool Delete(string code)
        {
            var s = _context.Systems.FirstOrDefault(x => x.Code == code);
            if (s == null) return false;
            _context.Systems.Remove(s);
            _context.SaveChanges();
            return true;
        }
    }
}