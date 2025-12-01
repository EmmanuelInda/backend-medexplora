using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class BodyPartServicio
    {
        private readonly MedexploraContext _context;

        public BodyPartServicio(MedexploraContext context)
        {
            _context = context;
        }


        // Get All Body Parts
        public IEnumerable<BodyPartDTO> GetAll()
        {
            return _context.BodyParts
                .Include(bp => bp.BodySections)
                .AsNoTracking()
                .ToList()
                .Select(MapToDTO);
        }

        // Get Body Part by Id

        public BodyPartDTO? GetById(int id)
        {
            var p = _context.BodyParts
                .Include(bp => bp.BodySections)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return p == null ? null : MapToDTO(p);
        }


        // Create Body Part
        public BodyPartDTO Create(BodyPartCreateDTO dto)
        {
            var nuevo = new BodyPart
            {
                ParentId = dto.ParentId,
                Slug = dto.Slug,
                NameEs = dto.NameEs,
                NameEn = dto.NameEn,
                DescriptionEs = dto.DescriptionEs,
                DescriptionEn = dto.DescriptionEn,
                Side = dto.Side,
                Sex = dto.Sex,
                SystemCode = dto.SystemCode,
                RegionCode = dto.RegionCode,
                ModelId = dto.ModelId,
                MeshKey = dto.MeshKey,
                SortOrder = dto.SortOrder,
                IsVisible = dto.IsVisible,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.BodyParts.Add(nuevo);
            _context.SaveChanges();

            return GetById(nuevo.Id)!;
        }


        // Update Body Part
        public BodyPartDTO? Update(int id, BodyPartCreateDTO dto)
        {
            var body = _context.BodyParts.FirstOrDefault(p => p.Id == id);
            if (body == null) return null;

            body.ParentId = dto.ParentId;
            body.Slug = dto.Slug;
            body.NameEs = dto.NameEs;
            body.NameEn = dto.NameEn;
            body.DescriptionEs = dto.DescriptionEs;
            body.DescriptionEn = dto.DescriptionEn;
            body.Side = dto.Side;
            body.Sex = dto.Sex;
            body.SystemCode = dto.SystemCode;
            body.RegionCode = dto.RegionCode;
            body.ModelId = dto.ModelId;
            body.MeshKey = dto.MeshKey;
            body.SortOrder = dto.SortOrder;
            body.IsVisible = dto.IsVisible;
            body.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return GetById(id);
        }

        // Delete Body Part
        public bool Delete(int id)
        {
            var body = _context.BodyParts.FirstOrDefault(p => p.Id == id);
            if (body == null) return false;

            _context.BodyParts.Remove(body);
            _context.SaveChanges();
            return true;
        }



        // Body Section 
        public BodySectionDTO AddSection(int bodyPartId, BodySectionCreateDTO dto)
        {
            var entity = new BodySection
            {
                BodyPartId = bodyPartId,
                Slug = dto.Slug,
                NameEs = dto.NameEs,
                NameEn = dto.NameEn,
                SortOrder = dto.SortOrder,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.BodySections.Add(entity);
            _context.SaveChanges();

            return new BodySectionDTO
            {
                Id = entity.Id,
                BodyPartId = entity.BodyPartId,
                Slug = entity.Slug,
                NameEs = entity.NameEs,
                NameEn = entity.NameEn,
                SortOrder = entity.SortOrder,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public bool UpdateSection(int sectionId, BodySectionCreateDTO dto)
        {
            var entity = _context.BodySections.FirstOrDefault(s => s.Id == sectionId);
            if (entity == null) return false;

            entity.Slug = dto.Slug;
            entity.NameEs = dto.NameEs;
            entity.NameEn = dto.NameEn;
            entity.SortOrder = dto.SortOrder;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteSection(int sectionId)
        {
            var entity = _context.BodySections.FirstOrDefault(s => s.Id == sectionId);
            if (entity == null) return false;

            _context.BodySections.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        private BodyPartDTO MapToDTO(BodyPart p)
        {
            return new BodyPartDTO
            {
                Id = p.Id,
                ParentId = p.ParentId,
                Slug = p.Slug,
                NameEs = p.NameEs,
                NameEn = p.NameEn,
                DescriptionEs = p.DescriptionEs,
                DescriptionEn = p.DescriptionEn,
                Side = p.Side,
                Sex = p.Sex,
                SystemCode = p.SystemCode,
                RegionCode = p.RegionCode,
                ModelId = p.ModelId,
                MeshKey = p.MeshKey,
                SortOrder = p.SortOrder,
                IsVisible = p.IsVisible,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Sections = p.BodySections
                    .Select(s => new BodySectionDTO
                    {
                        Id = s.Id,
                        BodyPartId = s.BodyPartId,
                        Slug = s.Slug,
                        NameEs = s.NameEs,
                        NameEn = s.NameEn,
                        SortOrder = s.SortOrder,
                        CreatedAt = s.CreatedAt,
                        UpdatedAt = s.UpdatedAt
                    })
                    .ToList()
            };
        }
    }
}
