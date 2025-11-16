using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedExploraAPI.Controlador
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class UsuarioControlador : ControllerBase
    {
    //    private readonly UsuarioServicio _usuarioServicio;

    //    public UsuarioControlador(UsuarioServicio usuarioServicio)
    //    {
    //        _usuarioServicio = usuarioServicio;
    //    }

    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
    //    {
    //        var usuarios = await _usuarioServicio.GetAllUsuarios();
    //        return Ok(usuarios);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
    //    {
    //        var usuario = await _usuarioServicio.GetUsuarioById(id);
    //        if (usuario == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(usuario);
    //    }

    //    [HttpGet("email/{email}")]
    //    public async Task<ActionResult<UsuarioDTO>> GetUsuarioPorEmail(string email)
    //    {
    //        var usuario = await _usuarioServicio.GetUsuarioByEmail(email);
    //        if (usuario == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(usuario);
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioCreateDTO createDTO)
    //    {
    //        var nuevoUsuario = await _usuarioServicio.CreateUsuario(createDTO);

    //        return CreatedAtAction(
    //            nameof(GetUsuario),
    //            new { id = nuevoUsuario.Id },
    //            nuevoUsuario);
    //    }
    }
}