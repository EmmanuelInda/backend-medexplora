namespace MedExploraAPI.DTO
{
    public class BodySectionCreateDTO
    {
        public int BodyPartId { get; set; }
        public string Slug { get; set; }
        public string NameEs { get; set; }
        public string NameEn { get; set; }
        public int? SortOrder { get; set; }
    }
}
