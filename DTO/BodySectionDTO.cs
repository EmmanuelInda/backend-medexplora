namespace MedExploraAPI.DTO
{
    public class BodySectionDTO
    {
        public int Id { get; set; }
        public int BodyPartId { get; set; }
        public string Slug { get; set; }
        public string NameEs { get; set; }
        public string NameEn { get; set; }
        public int? SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
