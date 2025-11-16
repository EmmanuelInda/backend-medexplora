namespace MedExploraAPI.DTO
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string FilePath { get; set; }
        public string? Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
