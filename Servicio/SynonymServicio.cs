using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class SynonymServicio
    {
        private readonly MedexploraContext _context;
        public SynonymServicio(MedexploraContext context) { _context = context; }

        public IEnumerable<SynonymDTO> GetAll()
        {
            return _context.Synonyms.AsNoTracking().Select(MapToDTO).ToList();
        }

        public SynonymDTO? GetById(int id)
        {
            var s = _context.Synonyms.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return s == null ? null : MapToDTO(s);
        }

        // Extra �til: buscar por bodyPartId
        public IEnumerable<SynonymDTO> GetByBodyPart(int bodyPartId)
        {
            return _context.Synonyms.Where(s => s.BodyPartId == bodyPartId).AsNoTracking().Select(MapToDTO).ToList();
        }

        public SynonymDTO Create(SynonymCreateDTO dto)
        {
            var nuevo = new Synonym { BodyPartId = dto.BodyPartId, Lang = dto.Lang, Term = dto.Term };
            _context.Synonyms.Add(nuevo);
            _context.SaveChanges();
            return GetById(nuevo.Id)!;
        }

        public SynonymDTO? Update(int id, SynonymCreateDTO dto)
        {
            var s = _context.Synonyms.FirstOrDefault(x => x.Id == id);
            if (s == null) return null;
            s.BodyPartId = dto.BodyPartId;
            s.Lang = dto.Lang;
            s.Term = dto.Term;
            _context.SaveChanges();
            return GetById(id);
        }

        public bool Delete(int id)
        {
            var s = _context.Synonyms.FirstOrDefault(x => x.Id == id);
            if (s == null) return false;
            _context.Synonyms.Remove(s);
            _context.SaveChanges();
            return true;
        }

        private static SynonymDTO MapToDTO(Synonym s) => new SynonymDTO { Id = s.Id, BodyPartId = s.BodyPartId, Lang = s.Lang, Term = s.Term };
    }
}