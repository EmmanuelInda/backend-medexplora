namespace MedExploraAPI.DTO
{
    public class RelatedPartCreateDTO
    {
        public int SourcePartId { get; set; }
        public int TargetPartId { get; set; }
        public string RelationType { get; set; } = null!;
        // Ej: 'parte_de', 'inervada_por'
    }

    public class RelatedPartDTO
    {
        public int Id { get; set; }
        public int SourcePartId { get; set; }
        public int TargetPartId { get; set; }
        public string RelationType { get; set; }
    }
}