namespace MedExploraAPI.DTO
{
    // DTO para crear una nueva parte del cuerpo
    public class ParteCuerpoCreateDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EnfermedadesAsociadas { get; set; }
    }
}
