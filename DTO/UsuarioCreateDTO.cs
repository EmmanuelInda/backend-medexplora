using System.ComponentModel.DataAnnotations;

namespace MedExploraAPI.DTO
{
    public class UsuarioCreateDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es v�lido")]
        public string Email { get; set; }

        [Range(1, 120, ErrorMessage = "La edad debe ser un valor entre 1 y 120")]
        public int? Edad { get; set; }
    }
}