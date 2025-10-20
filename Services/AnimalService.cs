
    using Microsoft.EntityFrameworkCore;
    using APIprueba.DTOs;
   using APIprueba.Models.DB;

    namespace APIprueba.Services
    {
        public class AnimalService
        {
            private readonly AnimalesContext _context;

            public AnimalService(AnimalesContext context)
            {
                _context = context;
            }

            public List<AnimalReadDTO> GetAll()
            {
                return _context.Animales
                    .Select(a => new AnimalReadDTO
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        Especie = a.Especie,
                      
                    }).ToList();
            }

            public AnimalReadDTO CreateAnimal(AnimalCreateDTO dto)
            {
                var animal = new Animale
                {
                    Nombre = dto.Nombre,
                    Especie = dto.Especie,
                    Edad = dto.Edad,
                    Peso = dto.Peso,
                    Color = dto.Color
                };
                _context.Animales.Add(animal);
                _context.SaveChanges();

                return new AnimalReadDTO
                {
                    Id = animal.Id,
                    Nombre = animal.Nombre,
                    Especie = animal.Especie,
                    
                };
            }
        }
    }