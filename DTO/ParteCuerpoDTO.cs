namespace MedExploraAPI.DTO
{
    // DTO para transferir datos de partes del cuerpo
    public class ParteCuerpoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EnfermedadesAsociadas { get; set; }
    }
}
