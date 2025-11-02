using MedExploraAPI.DTO;
using MedExploraAPI.Models.DB;

namespace MedExploraAPI.Servicio
{

    
    public class ParteCuerpoServicio
    {
        // servicio para manejar las partes del cuerpo
        //private readonly MedexploraContext _context;

        //public ParteCuerpoServicio(MedexploraContext context)
        //{
        //    _context = context;
        //}

        //// obtiene todas las partes del cuerpo
        //public IEnumerable<ParteCuerpoDTO> GetAll()

        //{
        //    return _context.ParteCuerpos.Select(p => new ParteCuerpoDTO
        //    {
        //        Id = p.Id,
        //        Nombre = p.Nombre,
        //        Descripcion = p.Descripcion,
        //        EnfermedadesAsociadas = p.EnfermedadesAsociadas
        //    });
        //}

        //// obtiene una parte del cuerpo por id
        //public ParteCuerpoDTO? GetById(int id)
        //{
        //    var parte = _context.ParteCuerpos.FirstOrDefault(p => p.Id == id);
        //    if (parte == null)
        //        return null;

        //    return new ParteCuerpoDTO
        //    {
        //        Id = parte.Id,
        //        Nombre = parte.Nombre,
        //        Descripcion = parte.Descripcion,
        //        EnfermedadesAsociadas = parte.EnfermedadesAsociadas
        //    };
        //}

    

        ////actualiza la informacion de una parte del cuerpo
        //public ParteCuerpoDTO? Update(int id, ParteCuerpoCreateDTO dto)
        //{
        //    var parte = _context.ParteCuerpos.FirstOrDefault(p => p.Id == id);
        //    if (parte == null)
        //        return null;

        //    parte.Nombre = dto.Nombre;
        //    parte.Descripcion = dto.Descripcion;
        //    parte.EnfermedadesAsociadas = dto.EnfermedadesAsociadas;

        //    _context.SaveChanges();

        //    return new ParteCuerpoDTO
        //    {
        //        Id = parte.Id,
        //        Nombre = parte.Nombre,
        //        Descripcion = parte.Descripcion,
        //        EnfermedadesAsociadas = parte.EnfermedadesAsociadas
        //    };
        //}

        //// busca por nombre o alguna palabra clave
        //public IEnumerable<ParteCuerpoDTO> BuscarPorNombre(string nombre)
        //{
        //    return _context.ParteCuerpos
        //        .Where(p => p.Nombre.Contains(nombre))
        //        .Select(p => new ParteCuerpoDTO
        //        {
        //            Id = p.Id,
        //            Nombre = p.Nombre,
        //            Descripcion = p.Descripcion,
        //            EnfermedadesAsociadas = p.EnfermedadesAsociadas
        //        });
        //}


        ////agrega una nueva parte del cuerpo
        //public ParteCuerpoDTO Create(ParteCuerpoCreateDTO dto)
        //{
        //    var nuevo = new ParteCuerpo
        //    {
                
        //        Id = (_context.ParteCuerpos.Any() ? _context.ParteCuerpos.Max(p => p.Id) : 0) + 1,
        //        Nombre = dto.Nombre,
        //        Descripcion = dto.Descripcion,
        //        EnfermedadesAsociadas = dto.EnfermedadesAsociadas
        //    };
        //    _context.ParteCuerpos.Add(nuevo);
        //    _context.SaveChanges();

        //    return new ParteCuerpoDTO
        //    {
        //        Id = nuevo.Id,
        //        Nombre = nuevo.Nombre,
        //        Descripcion = nuevo.Descripcion,
        //        EnfermedadesAsociadas = nuevo.EnfermedadesAsociadas
        //    };
        //}
    }
}
