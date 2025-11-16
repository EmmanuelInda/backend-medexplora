using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;  
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class MediaAssetServicio
    {
        private readonly MedexploraContext _context;

        public MediaAssetServicio(MedexploraContext context)
        {
            _context = context;
        }

        public IEnumerable<MediaAssetDTO> GetAll()
        {
            return _context.MediaAssets
                .AsNoTracking()
                .ToList()          // trae entidades a memoria
                .Select(MapToDTO); // mapea en memoria
        }


        public MediaAssetDTO? GetById(int id)
        {
            var m = _context.MediaAssets
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return m == null ? null : MapToDTO(m);
        }

        public IEnumerable<MediaAssetDTO> GetByBodyPartId(int bodyPartId)
        {
            return _context.MediaAssets
                .Where(m => m.BodyPartId == bodyPartId)
                .Select(m => MapToDTO(m))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<MediaAssetDTO> GetByType(string type)
        {
            return _context.MediaAssets
                .Where(m => m.Type == type)
                .Select(m => MapToDTO(m))
                .AsNoTracking()
                .ToList();
        }

        public MediaAssetDTO Create(MediaAssetCreateDTO dto)
        {
            var nuevo = new MediaAsset
            {
                BodyPartId = dto.BodyPartId,
                Type = dto.Type,
                Path = dto.Path,
                CaptionEs = dto.CaptionEs,
                CaptionEn = dto.CaptionEn,
                Attribution = dto.Attribution,
                License = dto.License,
                CreatedAt = DateTime.Now
            };

            _context.MediaAssets.Add(nuevo);
            _context.SaveChanges();

            return GetById(nuevo.Id)!;
        }

        public MediaAssetDTO? Update(int id, MediaAssetCreateDTO dto)
        {
            var m = _context.MediaAssets.FirstOrDefault(x => x.Id == id);
            if (m == null) return null;

            m.BodyPartId = dto.BodyPartId;
            m.Type = dto.Type;
            m.Path = dto.Path;
            m.CaptionEs = dto.CaptionEs;
            m.CaptionEn = dto.CaptionEn;
            m.Attribution = dto.Attribution;
            m.License = dto.License;

            _context.SaveChanges();

            return GetById(id);
        }

        public bool Delete(int id)
        {
            var m = _context.MediaAssets.FirstOrDefault(x => x.Id == id);
            if (m == null) return false;

            _context.MediaAssets.Remove(m);
            _context.SaveChanges();
            return true;
        }

        private static MediaAssetDTO MapToDTO(MediaAsset m)
        {
            return new MediaAssetDTO {
                Id = m.Id,
                BodyPartId = m.BodyPartId,
                Type = m.Type,
                Path = m.Path,
                CaptionEs = m.CaptionEs,
                CaptionEn = m.CaptionEn,
                Attribution = m.Attribution,
                License = m.License,
                CreatedAt = m.CreatedAt
            };
        }
    }
}
