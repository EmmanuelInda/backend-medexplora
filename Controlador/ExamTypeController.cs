using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamTypeController : ControllerBase
    {
        private readonly ExamTypeServicio _servicio;
        public ExamTypeController(ExamTypeServicio servicio) { _servicio = servicio; }

        [HttpGet] public IActionResult GetAll() => Ok(_servicio.GetAll());

        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var e = _servicio.GetByCode(code);
            return e == null ? NotFound() : Ok(e);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExamTypeCreateDTO dto)
        {
            try
            {
                var e = _servicio.Create(dto);
                return CreatedAtAction(nameof(GetByCode), new { code = e.Code }, e);
            }
            catch { return BadRequest("Error al crear (posible código duplicado)"); }
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] ExamTypeCreateDTO dto)
        {
            var e = _servicio.Update(code, dto);
            return e == null ? NotFound() : Ok(e);
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code) => _servicio.Delete(code) ? NoContent() : NotFound();
    }
}