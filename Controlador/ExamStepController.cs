using Microsoft.AspNetCore.Mvc;
using MedExploraAPI.Servicio;
using MedExploraAPI.DTO;

namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamStepController : ControllerBase
    {
        private readonly ExamStepServicio _servicio;

        public ExamStepController(ExamStepServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExamStepDTO>> GetAll()
        {
            return Ok(_servicio.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ExamStepDTO> GetById(int id)
        {
            var result = _servicio.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public ActionResult<ExamStepDTO> Create(ExamStepCreateDTO dto)
        {
            var result = _servicio.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ExamStepCreateDTO dto)
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
