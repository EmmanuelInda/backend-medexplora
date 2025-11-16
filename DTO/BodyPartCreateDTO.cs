namespace MedExploraAPI.DTO
{
    public class BodyPartCreateDTO
    {
        public int? ParentId { get; set; }
        public string Slug { get; set; }
        public string NameEs { get; set; }
        public string NameEn { get; set; }
        public string? DescriptionEs { get; set; }
        public string? DescriptionEn { get; set; }
        public string? Side { get; set; }
        public string? Sex { get; set; }
        public string? SystemCode { get; set; }
        public string? RegionCode { get; set; }
        public int ModelId { get; set; }
        public string? MeshKey { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsVisible { get; set; }
    }
}
