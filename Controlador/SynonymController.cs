using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SynonymController : ControllerBase
    {
        private readonly SynonymServicio _servicio;
        public SynonymController(SynonymServicio servicio) { _servicio = servicio; }

        [HttpGet] public IActionResult GetAll() => Ok(_servicio.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var s = _servicio.GetById(id);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SynonymCreateDTO dto)
        {
            var s = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SynonymCreateDTO dto)
        {
            var s = _servicio.Update(id, dto);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _servicio.Delete(id) ? NoContent() : NotFound();
    }
}