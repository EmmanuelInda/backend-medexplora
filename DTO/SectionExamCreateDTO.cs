namespace MedExploraAPI.DTO
{
    public class SectionExamCreateDTO
    {
        public int SectionId { get; set; }
        public required string ExamTypeCode { get; set; }
        public required string TitleEs { get; set; }
        public string? TitleEn { get; set; }
        public string? SummaryEs { get; set; }
        public string? SummaryEn { get; set; }
        public string? SourceRef { get; set; }
    }

    public class SectionExamDTO
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string ExamTypeCode { get; set; }
        public string TitleEs { get; set; }
        public string? TitleEn { get; set; }
        public string? SummaryEs { get; set; }
        public string? SummaryEn { get; set; }
        public string? SourceRef { get; set; }
    }
}