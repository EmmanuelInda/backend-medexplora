using MedExploraAPI.Models.DB;
using MedExploraAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedExploraAPI.Servicio
{
    public class UsuarioServicio
    {
        private readonly MedexploraContext _context;

        public UsuarioServicio(MedexploraContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuarios()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Edad = u.Edad
                })
                .ToListAsync();
        }

        public async Task<UsuarioDTO?> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Edad = usuario.Edad
            };
        }

        public async Task<UsuarioDTO?> GetUsuarioByEmail(string email)
        {
            var usuario = await _context.Usuarios
                                        .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Edad = usuario.Edad
            };
        }

        public async Task<UsuarioDTO> CreateUsuario(UsuarioCreateDTO createDTO)
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = createDTO.Nombre,
                Email = createDTO.Email,
                Edad = createDTO.Edad
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return new UsuarioDTO
            {
                Id = nuevoUsuario.Id,
                Nombre = nuevoUsuario.Nombre,
                Email = nuevoUsuario.Email,
                Edad = nuevoUsuario.Edad
            };
        }
    }
}