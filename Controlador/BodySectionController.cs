using Microsoft.AspNetCore.Mvc;
using MedExploraAPI.Servicio;
using MedExploraAPI.DTO;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodySectionController : ControllerBase
    {
        private readonly BodySectionServicio _servicio;

        public BodySectionController(BodySectionServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BodySectionDTO>> GetAll()
        {
            return Ok(_servicio.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BodySectionDTO> GetById(int id)
        {
            var result = _servicio.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public ActionResult<BodySectionDTO> Create(BodySectionCreateDTO dto)
        {
            var result = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BodySectionCreateDTO dto)
        {
            return _servicio.Update(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _servicio.Delete(id) ? NoContent() : NotFound();
        }
    }
}
