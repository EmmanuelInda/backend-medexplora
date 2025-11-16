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

        //get all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_servicio.GetAll());
        }

        //get por id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bodyPart = _servicio.GetById(id);
            if (bodyPart == null) return NotFound();
            return Ok(bodyPart);
        }
        // get por parentId
        [HttpGet("parent/{parentId}")]
        public IActionResult GetByParentId(int parentId)
        {
            var list = _servicio.GetAll().Where(p => p.ParentId == parentId);
            return Ok(list);
        }

        //get por slug
        [HttpGet("slug/{slug}")]
        public IActionResult GetBySlug(string slug)
        {
            var result = _servicio.GetBySlug(slug);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // get por nombre español
        [HttpGet("nameEs/{name}")]
        public IActionResult GetByNameEs(string name)
        {
            var list = _servicio.GetAll().Where(p => p.NameEs.Contains(name));
            return Ok(list);
        }

        //get por nombre inglés
        [HttpGet("nameEn/{name}")]
        public IActionResult GetByNameEn(string name)
        {
            var list = _servicio.GetAll().Where(p => p.NameEn.Contains(name));
            return Ok(list);
        }

        //get por lado del cuerpo
        [HttpGet("side/{side}")]
        public IActionResult GetBySide(string side)
        {
            var list = _servicio.GetAll().Where(p => p.Side == side);
            return Ok(list);
        }

        //get   por sex
        [HttpGet("sex/{sex}")]
        public IActionResult GetBySex(string sex)
        {
            var list = _servicio.GetAll().Where(p => p.Sex == sex);
            return Ok(list);
        }

        //get por systemCode
        [HttpGet("system/{systemCode}")]
        public IActionResult GetBySystemCode(string systemCode)
        {
            var list = _servicio.GetAll().Where(p => p.SystemCode == systemCode);
            return Ok(list);
        }

        //get por regionCode
        [HttpGet("region/{regionCode}")]
        public IActionResult GetByRegionCode(string regionCode)
        {
            var list = _servicio.GetAll().Where(p => p.RegionCode == regionCode);
            return Ok(list);
        }

        // get por modelId
        [HttpGet("model/{modelId}")]
        public IActionResult GetByModelId(int modelId)
        {
            var list = _servicio.GetAll().Where(p => p.ModelId == modelId);
            return Ok(list);
        }
        // get por meshKey
        [HttpGet("mesh/{meshKey}")]
        public IActionResult GetByMeshKey(string meshKey)
        {
            var list = _servicio.GetAll().Where(p => p.MeshKey == meshKey);
            return Ok(list);
        }

        //get ordenados
        [HttpGet("sort/{sortOrder}")]
        public IActionResult GetBySortOrder(int sortOrder)
        {
            var list = _servicio.GetAll().Where(p => p.SortOrder == sortOrder);
            return Ok(list);
        }
        // get por visibilidad
        [HttpGet("visible/{isVisible}")]
        public IActionResult GetByIsVisible(bool isVisible)
        {
            var list = _servicio.GetAll().Where(p => p.IsVisible == isVisible);
            return Ok(list);
        }

       //get por fecha de creacion
        [HttpGet("createdAfter/{date}")]
        public IActionResult GetCreatedAfter(DateTime date)
        {
            var list = _servicio.GetAll().Where(p => p.CreatedAt >= date);
            return Ok(list);
        }

        //crear nuevo bodypart
        [HttpPost]
        public IActionResult Create([FromBody] BodyPartCreateDTO dto)
        {
            var nuevo = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

       //actualizar bodypart
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BodyPartCreateDTO dto)
        {
            var updated = _servicio.Update(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        //eliminar bodypart
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _servicio.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
