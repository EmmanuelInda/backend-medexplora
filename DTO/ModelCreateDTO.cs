namespace MedExploraAPI.DTO
{
    public class ModelCreateDTO
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string FilePath { get; set; }
        public string? Version { get; set; }
    }
}
