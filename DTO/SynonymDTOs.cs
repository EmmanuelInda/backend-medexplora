namespace MedExploraAPI.DTO
{
    public class SynonymCreateDTO
    {
        public int BodyPartId { get; set; }
        public string Lang { get; set; } = null!; // 'es' o 'en'
        public string Term { get; set; } = null!;
    }

    public class SynonymDTO
    {
        public int Id { get; set; }
        public int BodyPartId { get; set; }
        public string Lang { get; set; }
        public string Term { get; set; }
    }
}