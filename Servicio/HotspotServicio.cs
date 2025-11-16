using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class HotspotServicio
    {
        private readonly MedexploraContext _context;

        public HotspotServicio(MedexploraContext context)
        {
            _context = context;
        }

        public IEnumerable<HotspotDTO> GetAll()
        {
            return _context.Hotspots
                .AsNoTracking()
                .ToList()          // trae entidades a memoria
                .Select(MapToDTO); // mapea en memoria
        }

        public HotspotDTO? GetById(int id)
        {
            var h = _context.Hotspots
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            return h == null ? null : MapToDTO(h);
        }

        public IEnumerable<HotspotDTO> GetByBodyPartId(int bodyPartId)
        {
            return _context.Hotspots
                .Where(h => h.BodyPartId == bodyPartId)
                .Select(h => MapToDTO(h))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<HotspotDTO> GetByModelId(int modelId)
        {
            return _context.Hotspots
                .Where(h => h.ModelId == modelId)
                .Select(h => MapToDTO(h))
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<HotspotDTO> GetByMeshName(string meshName)
        {
            return _context.Hotspots
                .Where(h => h.MeshName == meshName)
                .Select(h => MapToDTO(h))
                .AsNoTracking()
                .ToList();
        }

        public HotspotDTO Create(HotspotCreateDTO dto)
        {
            var nuevo = new Hotspot
            {
                BodyPartId = dto.BodyPartId,
                ModelId = dto.ModelId,
                MeshName = dto.MeshName,
                X = dto.X,
                Y = dto.Y,
                Z = dto.Z
            };

            _context.Hotspots.Add(nuevo);
            _context.SaveChanges();

            return GetById(nuevo.Id)!;
        }

        public HotspotDTO? Update(int id, HotspotCreateDTO dto)
        {
            var h = _context.Hotspots.FirstOrDefault(x => x.Id == id);
            if (h == null) return null;

            h.BodyPartId = dto.BodyPartId;
            h.ModelId = dto.ModelId;
            h.MeshName = dto.MeshName;
            h.X = dto.X;
            h.Y = dto.Y;
            h.Z = dto.Z;

            _context.SaveChanges();

            return GetById(id);
        }

        public bool Delete(int id)
        {
            var h = _context.Hotspots.FirstOrDefault(x => x.Id == id);
            if (h == null) return false;

            _context.Hotspots.Remove(h);
            _context.SaveChanges();
            return true;
        }

        private HotspotDTO MapToDTO(Hotspot h)
        {
            return new HotspotDTO
            {
                Id = h.Id,
                BodyPartId = h.BodyPartId,
                ModelId = h.ModelId,
                MeshName = h.MeshName,
                X = h.X,
                Y = h.Y,
                Z = h.Z
            };
        }
    }
}
