using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class RelatedPartServicio
    {
        private readonly MedexploraContext _context;
        public RelatedPartServicio(MedexploraContext context) { _context = context; }

        public IEnumerable<RelatedPartDTO> GetAll()
        {
            return _context.RelatedParts.AsNoTracking().Select(MapToDTO).ToList();
        }

        public RelatedPartDTO? GetById(int id)
        {
            var r = _context.RelatedParts.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return r == null ? null : MapToDTO(r);
        }

        public RelatedPartDTO Create(RelatedPartCreateDTO dto)
        {
            var nuevo = new RelatedPart
            {
                SourcePartId = dto.SourcePartId,
                TargetPartId = dto.TargetPartId,
                RelationType = dto.RelationType
            };
            _context.RelatedParts.Add(nuevo);
            _context.SaveChanges();
            return GetById(nuevo.Id)!;
        }

        public RelatedPartDTO? Update(int id, RelatedPartCreateDTO dto)
        {
            var r = _context.RelatedParts.FirstOrDefault(x => x.Id == id);
            if (r == null) return null;
            r.SourcePartId = dto.SourcePartId;
            r.TargetPartId = dto.TargetPartId;
            r.RelationType = dto.RelationType;
            _context.SaveChanges();
            return GetById(id);
        }

        public bool Delete(int id)
        {
            var r = _context.RelatedParts.FirstOrDefault(x => x.Id == id);
            if (r == null) return false;
            _context.RelatedParts.Remove(r);
            _context.SaveChanges();
            return true;
        }

        private static RelatedPartDTO MapToDTO(RelatedPart r)
            => new RelatedPartDTO { Id = r.Id, SourcePartId = r.SourcePartId, TargetPartId = r.TargetPartId, RelationType = r.RelationType };
    }
}