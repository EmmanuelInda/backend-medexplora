using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/modelos")]
    public class ModelController : ControllerBase
    {
        private readonly ModelServicio _servicio;

        public ModelController(ModelServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_servicio.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var r = _servicio.GetById(id);
            if (r == null) return NotFound();
            return Ok(r);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ModelCreateDTO dto)
        {
            var r = _servicio.Create(dto);
            return Ok(r);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ModelCreateDTO dto)
        {
            var r = _servicio.Update(id, dto);
            if (r == null) return NotFound();
            return Ok(r);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ok = _servicio.Delete(id);
            if (!ok) return NotFound();
            return Ok();
        }
    }
}
