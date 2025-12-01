using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyPartController : ControllerBase
    {
        private readonly BodyPartServicio _servicio;

        public BodyPartController(BodyPartServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_servicio.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var body = _servicio.GetById(id);
            if (body == null) return NotFound();
            return Ok(body);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BodyPartCreateDTO dto)
        {
            var nuevo = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BodyPartCreateDTO dto)
        {
            var updated = _servicio.Update(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _servicio.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }


        // GET: api/bodypart/{bodyPartId}/sections
        [HttpGet("{bodyPartId}/sections")]
        public IActionResult GetSectionsByBodyPart(int bodyPartId)
        {
            var bodyPart = _servicio.GetById(bodyPartId);
            if (bodyPart == null) return NotFound();
            return Ok(bodyPart.Sections);
        }

        // GET: api/bodypart/sections/{sectionId}
        [HttpGet("sections/{sectionId}")]
        public IActionResult GetSectionById(int sectionId)
        {
            // Como BodySectionServicio ya no existe, usamos el BodyPartServicio
            var allBodyParts = _servicio.GetAll();
            var section = allBodyParts
                .SelectMany(bp => bp.Sections)
                .FirstOrDefault(s => s.Id == sectionId);

            if (section == null) return NotFound();
            return Ok(section);
        }



        //bodysec

        [HttpPost("{bodyPartId}/sections")]
        public IActionResult AddSection(int bodyPartId, [FromBody] BodySectionCreateDTO dto)
        {
            var section = _servicio.AddSection(bodyPartId, dto);
            return CreatedAtAction(nameof(GetById), new { id = bodyPartId }, section);
        }

        [HttpPut("sections/{sectionId}")]
        public IActionResult UpdateSection(int sectionId, [FromBody] BodySectionCreateDTO dto)
        {
            var updated = _servicio.UpdateSection(sectionId, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("sections/{sectionId}")]
        public IActionResult DeleteSection(int sectionId)
        {
            var deleted = _servicio.DeleteSection(sectionId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
