using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatedPartController : ControllerBase
    {
        private readonly RelatedPartServicio _servicio;
        public RelatedPartController(RelatedPartServicio servicio) { _servicio = servicio; }

        [HttpGet] public IActionResult GetAll() => Ok(_servicio.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var r = _servicio.GetById(id);
            return r == null ? NotFound() : Ok(r);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RelatedPartCreateDTO dto)
        {
            var r = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = r.Id }, r);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RelatedPartCreateDTO dto)
        {
            var r = _servicio.Update(id, dto);
            return r == null ? NotFound() : Ok(r);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _servicio.Delete(id) ? NoContent() : NotFound();
    }
}