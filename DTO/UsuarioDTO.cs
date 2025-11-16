namespace MedExploraAPI.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; } // <-- Mantenemos la edad opcional
    }
}