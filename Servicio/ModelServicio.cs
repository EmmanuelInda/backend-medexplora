using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MedExploraAPI.Servicio
{
    public class ModelServicio
    {
        private readonly MedexploraContext _context;

        public ModelServicio(MedexploraContext context)
        {
            _context = context;
        }

        public IEnumerable<ModelDTO> GetAll()
        {
            return _context.Models
                .AsNoTracking()
                .Select(p => new ModelDTO
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    FilePath = p.FilePath,
                    Version = p.Version,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .ToList();
        }

        public ModelDTO? GetById(int id)
        {
            var m = _context.Models
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return m == null ? null : MapToDTO(m);
        }

        public ModelDTO Create(ModelCreateDTO dto)
        {
            var nuevo = new Model
            {
                Code = dto.Code,
                Name = dto.Name,
                FilePath = dto.FilePath,
                Version = dto.Version,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Models.Add(nuevo);
            _context.SaveChanges();

            return GetById(nuevo.Id)!;
        }

        public ModelDTO? Update(int id, ModelCreateDTO dto)
        {
            var m = _context.Models.FirstOrDefault(p => p.Id == id);
            if (m == null) return null;

            m.Code = dto.Code;
            m.Name = dto.Name;
            m.FilePath = dto.FilePath;
            m.Version = dto.Version;
            m.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return GetById(id);
        }

        public bool Delete(int id)
        {
            var m = _context.Models.FirstOrDefault(p => p.Id == id);
            if (m == null) return false;

            _context.Models.Remove(m);
            _context.SaveChanges();
            return true;
        }

        private ModelDTO MapToDTO(Model p)
        {
            return new ModelDTO
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                FilePath = p.FilePath,
                Version = p.Version,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            };
        }
    }
}
