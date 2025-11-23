using MedExploraAPI.Models.DB;
using MedExploraAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class BodySectionServicio
    {
        private readonly MedexploraContext _context;

        public BodySectionServicio(MedexploraContext context)
        {
            _context = context;
        }

        public IEnumerable<BodySectionDTO> GetAll()
        {
            return _context.BodySections
                .AsNoTracking()
                .ToList()
                .Select(MapToDTO);
        }

        public BodySectionDTO? GetById(int id)
        {
            var entity = _context.BodySections
                .AsNoTracking()
                .FirstOrDefault(b => b.Id == id);

            return entity == null ? null : MapToDTO(entity);
        }

        public BodySectionDTO Create(BodySectionCreateDTO dto)
        {
            var entity = new BodySection
            {
                BodyPartId = dto.BodyPartId,
                Slug = dto.Slug,
                NameEs = dto.NameEs,
                NameEn = dto.NameEn,
                SortOrder = dto.SortOrder,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.BodySections.Add(entity);
            _context.SaveChanges();

            return MapToDTO(entity);
        }

        public bool Update(int id, BodySectionCreateDTO dto)
        {
            var entity = _context.BodySections.FirstOrDefault(b => b.Id == id);
            if (entity == null) return false;

            entity.BodyPartId = dto.BodyPartId;
            entity.Slug = dto.Slug;
            entity.NameEs = dto.NameEs;
            entity.NameEn = dto.NameEn;
            entity.SortOrder = dto.SortOrder;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.BodySections.FirstOrDefault(b => b.Id == id);
            if (entity == null) return false;

            _context.BodySections.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        private BodySectionDTO MapToDTO(BodySection b)
        {
            return new BodySectionDTO
            {
                Id = b.Id,
                BodyPartId = b.BodyPartId,
                Slug = b.Slug,
                NameEs = b.NameEs,
                NameEn = b.NameEn,
                SortOrder = b.SortOrder,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            };
        }
    }
}
