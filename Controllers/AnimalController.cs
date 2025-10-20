using APIprueba.DTOs;
using APIprueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIprueba.Controllers
{
   

 
        [ApiController]
        [Route("api/[controller]")]
        public class AnimalController : ControllerBase
        {
            private readonly AnimalService _service;

            public AnimalController(AnimalService service)
            {
                _service = service;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_service.GetAll());
            }

            [HttpPost]
            public IActionResult Create([FromBody] AnimalCreateDTO dto)
            {
                var result = _service.CreateAnimal(dto);
                return Ok(result);
            }
        }
    

}
