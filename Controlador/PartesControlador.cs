using MedExploraAPI.DTO;
using MedExploraAPI.Servicio;
using Microsoft.AspNetCore.Mvc;



// controlador para manejar las solicitudes relacionadas con las partes del cuerpo
namespace MedExploraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Produces("application/json")]
    public class ParteCuerpoController : ControllerBase
    {
        private readonly ParteCuerpoServicio _service;

        public ParteCuerpoController(ParteCuerpoServicio service)
        {
            _service = service;
        }

        //get by sistema
        //get byenfermedad?
        //get by region
        //get by funcion


        //// Endpoint para buscar partes del cuerpo por nombre
        //[HttpGet("buscar")]
        //public IActionResult Buscar([FromQuery] string nombre)
        //{
        //    var resultados = _service.BuscarPorNombre(nombre);
        //    return Ok(resultados);
        //}

        //// Endpoint para obtener todas las partes del cuerpo
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_service.GetAll());
        //}

        //// Endpoint para obtener una parte del cuerpo por ID
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{   
            
        //    var parte = _service.GetById(id);
        //    if (parte == null)
        //        return NotFound(new { message = "Parte del cuerpo no encontrada" });

        //    return Ok(parte);
        //}

        //// Endpoint para crear una nueva parte del cuerpo
        //[HttpPost]
        //public IActionResult Create([FromBody] ParteCuerpoCreateDTO dto)
        //{
        //    var result = _service.Create(dto);
        //    return Ok(result);
        //}
    }
}
