using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly RegionServicio _servicio;
        public RegionController(RegionServicio servicio) { _servicio = servicio; }

        // obtener todas las regiones
        [HttpGet] public IActionResult GetAll() => Ok(_servicio.GetAll());

        // obtener por código
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var r = _servicio.GetByCode(code);
            return r == null ? NotFound() : Ok(r);
        }

        // crear nueva región
        [HttpPost]
        public IActionResult Create([FromBody] RegionCreateDTO dto)
        {
            try { var r = _servicio.Create(dto); return CreatedAtAction(nameof(GetByCode), new { code = r.Code }, r); }
            catch { return BadRequest("Error al crear (posible codigo duplicado)"); }
        }

        // actualizar por código
        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] RegionCreateDTO dto)
        {
            var r = _servicio.Update(code, dto);
            return r == null ? NotFound() : Ok(r);
        }

        // borrar por código
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return _servicio.Delete(code) ? NoContent() : NotFound();
        }
    }
}