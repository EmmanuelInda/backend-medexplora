using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaAssetController : ControllerBase
    {
        private readonly MediaAssetServicio _servicio;

        public MediaAssetController(MediaAssetServicio servicio)
        {
            _servicio = servicio;
        }

        // obtener todos los media assets   
        [HttpGet]
        public ActionResult<IEnumerable<MediaAssetDTO>> GetAll()
        {
            return Ok(_servicio.GetAll());
        }

        // obtener media asset por id
        [HttpGet("{id}")]
        public ActionResult<MediaAssetDTO> GetById(int id)
        {
            var m = _servicio.GetById(id);
            return m == null ? NotFound() : Ok(m);
        }

        // obtener media assets por bodyPartId
        [HttpGet("bodypart/{bodyPartId}")]
        public ActionResult<IEnumerable<MediaAssetDTO>> GetByBodyPartId(int bodyPartId)
        {
            return Ok(_servicio.GetByBodyPartId(bodyPartId));
        }

        // obtener media assets por tipo
        [HttpGet("type/{type}")]
        public ActionResult<IEnumerable<MediaAssetDTO>> GetByType(string type)
        {
            return Ok(_servicio.GetByType(type));
        }

        // crear un nuevo media asset
        [HttpPost]
        public ActionResult<MediaAssetDTO> Create([FromBody] MediaAssetCreateDTO dto)
        {
            var m = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = m.Id }, m);
        }

        // actualizar un media asset existente
        [HttpPut("{id}")]
        public ActionResult<MediaAssetDTO> Update(int id, [FromBody] MediaAssetCreateDTO dto)
        {
            var m = _servicio.Update(id, dto);
            return m == null ? NotFound() : Ok(m);
        }

        // borrar un media asset por id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _servicio.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}
