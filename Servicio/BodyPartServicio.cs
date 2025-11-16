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

        public IEnumerable<BodyPartDTO> GetAll()
        {
            return _context.BodyParts
                
                .AsNoTracking()
                .ToList()           // trae entidades a memoria
                .Select(MapToDTO);  // mapear en memoria usando método de instancia
        }

        public BodyPartDTO? GetById(int id)
        {
            var p = _context.BodyParts
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return p == null ? null : MapToDTO(p);
        }

        public IEnumerable<BodyPartDTO> GetByParentId(int parentId)
        {
            return _context.BodyParts
                .Where(p => p.ParentId == parentId)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public BodyPartDTO? GetBySlug(string slug)
        {
            var p = _context.BodyParts
                .AsNoTracking()
                .FirstOrDefault(p => p.Slug == slug);

            return p == null ? null : MapToDTO(p);
        }

        public IEnumerable<BodyPartDTO> GetByNameEs(string name)
        {
            return _context.BodyParts
                .Where(p => p.NameEs.Contains(name))
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetByNameEn(string name)
        {
            return _context.BodyParts
                .Where(p => p.NameEn.Contains(name))
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetBySide(string side)
        {
            return _context.BodyParts
                .Where(p => p.Side == side)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetBySex(string sex)
        {
            return _context.BodyParts
                .Where(p => p.Sex == sex)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetBySystemCode(string systemCode)
        {
            return _context.BodyParts
                .Where(p => p.SystemCode == systemCode)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetByRegionCode(string regionCode)
        {
            return _context.BodyParts
                .Where(p => p.RegionCode == regionCode)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetByModelId(int modelId)
        {
            return _context.BodyParts
                .Where(p => p.ModelId == modelId)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetByMeshKey(string meshKey)
        {
            return _context.BodyParts
                .Where(p => p.MeshKey == meshKey)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetBySortOrder(int sortOrder)
        {
            return _context.BodyParts
                .Where(p => p.SortOrder == sortOrder)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetByIsVisible(bool isVisible)
        {
            return _context.BodyParts
                .Where(p => p.IsVisible == isVisible)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<BodyPartDTO> GetCreatedAfter(DateTime date)
        {
            return _context.BodyParts
                .Where(p => p.CreatedAt >= date)
                .Select(p => MapToDTO(p))
                .AsNoTracking()
                .ToList();
        }

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
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.BodyParts.Add(nuevo);
            _context.SaveChanges();

            return GetById(nuevo.Id)!;
        }

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
            body.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return GetById(id);
        }

        public bool Delete(int id)
        {
            var body = _context.BodyParts.FirstOrDefault(p => p.Id == id);
            if (body == null) return false;

            _context.BodyParts.Remove(body);
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
                UpdatedAt = p.UpdatedAt
            };
        }
    }
}
