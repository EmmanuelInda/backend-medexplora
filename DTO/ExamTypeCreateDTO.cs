namespace MedExploraAPI.DTO
{
    public class ExamTypeCreateDTO
    {
        public required string Code { get; set; }
        public required string NameEs { get; set; }
        public required string NameEn { get; set; }
        public int? SortOrder { get; set; }
    }

    public class ExamTypeDTO
    {
        public string Code { get; set; }
        public string NameEs { get; set; }
        public string NameEn { get; set; }
        public int? SortOrder { get; set; }
    }
}