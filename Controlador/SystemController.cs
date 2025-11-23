using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // Controlador para gestionar sistemas
    public class SystemController : ControllerBase
    {
        private readonly SystemServicio _servicio;
        public SystemController(SystemServicio servicio) { _servicio = servicio; }

        // Obtener todos los sistemas
        [HttpGet] public IActionResult GetAll() => Ok(_servicio.GetAll());

        // Obtener sistema por código
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var s = _servicio.GetByCode(code);
            return s == null ? NotFound() : Ok(s);
        }

        // Crear un nuevo sistema
        [HttpPost]
        public IActionResult Create([FromBody] SystemCreateDTO dto)
        {
            try { var s = _servicio.Create(dto); return CreatedAtAction(nameof(GetByCode), new { code = s.Code }, s); }
            catch { return BadRequest("Error al crear"); }
        }

        // Actualizar un sistema existente
        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] SystemCreateDTO dto)
        {
            var s = _servicio.Update(code, dto);
            return s == null ? NotFound() : Ok(s);
        }

        // Borrar un sistema por código
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return _servicio.Delete(code) ? NoContent() : NotFound();
        }
    }
}