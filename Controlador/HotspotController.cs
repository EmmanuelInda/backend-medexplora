using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotspotController : ControllerBase
    {
        private readonly HotspotServicio _servicio;

        
        public HotspotController(HotspotServicio servicio)
        {
            _servicio = servicio;
        }

        //obtener todos los hotspots
        [HttpGet]
        public ActionResult<IEnumerable<HotspotDTO>> GetAll()
        {
            return Ok(_servicio.GetAll());
        }

        // obtener hotspot por id
        [HttpGet("{id}")]
        public ActionResult<HotspotDTO> GetById(int id)
        {
            var h = _servicio.GetById(id);
            return h == null ? NotFound() : Ok(h);
        }

        // obtener hotspots por bodypartId
        [HttpGet("bodypart/{bodyPartId}")]
        public ActionResult<IEnumerable<HotspotDTO>> GetByBodyPartId(int bodyPartId)
        {
            return Ok(_servicio.GetByBodyPartId(bodyPartId));
        }

        // obtener hotspots por modelId
        [HttpGet("model/{modelId}")]
        public ActionResult<IEnumerable<HotspotDTO>> GetByModelId(int modelId)
        {
            return Ok(_servicio.GetByModelId(modelId));
        }

        // obtener hotspots por meshName
        [HttpGet("mesh/{meshName}")]
        public ActionResult<IEnumerable<HotspotDTO>> GetByMeshName(string meshName)
        {
            return Ok(_servicio.GetByMeshName(meshName));
        }

        // crear un nuevo hotspot
        [HttpPost]
        public ActionResult<HotspotDTO> Create([FromBody] HotspotCreateDTO dto)
        {
            var h = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = h.Id }, h);
        }

        // actualizar un hotspot existente
        [HttpPut("{id}")]
        public ActionResult<HotspotDTO> Update(int id, [FromBody] HotspotCreateDTO dto)
        {
            var h = _servicio.Update(id, dto);
            return h == null ? NotFound() : Ok(h);
        }

        // borrar un hotspot por id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _servicio.Delete(id);
            return success ? NoContent() : NotFound();
        }
    }
}
