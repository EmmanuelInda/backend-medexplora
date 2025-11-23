namespace MedExploraAPI.DTO
{
    public class ExamStepCreateDTO
    {
        public int SectionExamId { get; set; }
        public int StepOrder { get; set; }
        public string LabelEs { get; set; }
        public string? DetailEs { get; set; }
        public string? LabelEn { get; set; }
        public string? DetailEn { get; set; }
    }
}
