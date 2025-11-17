using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class RegionServicio
    {
        private readonly MedexploraContext _context;

        public RegionServicio(MedexploraContext context)
        {
            _context = context;
        }

        public IEnumerable<RegionDTO> GetAll()
        {
            return _context.Regions.AsNoTracking().Select(r => new RegionDTO
            {
                Code = r.Code,
                NameEs = r.NameEs,
                NameEn = r.NameEn
            }).ToList();
        }

        public RegionDTO? GetByCode(string code)
        {
            var r = _context.Regions.AsNoTracking().FirstOrDefault(x => x.Code == code);
            return r == null ? null : new RegionDTO { Code = r.Code, NameEs = r.NameEs, NameEn = r.NameEn };
        }

        public RegionDTO Create(RegionCreateDTO dto)
        {
            var nueva = new Region { Code = dto.Code, NameEs = dto.NameEs, NameEn = dto.NameEn };
            _context.Regions.Add(nueva);
            _context.SaveChanges();
            return GetByCode(nueva.Code)!;
        }

        public RegionDTO? Update(string code, RegionCreateDTO dto)
        {
            var r = _context.Regions.FirstOrDefault(x => x.Code == code);
            if (r == null) return null;
            r.NameEs = dto.NameEs;
            r.NameEn = dto.NameEn;
            _context.SaveChanges();
            return GetByCode(code);
        }

        public bool Delete(string code)
        {
            var r = _context.Regions.FirstOrDefault(x => x.Code == code);
            if (r == null) return false;
            _context.Regions.Remove(r);
            _context.SaveChanges();
            return true;
        }
    }
}