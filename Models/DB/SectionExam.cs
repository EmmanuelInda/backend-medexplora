using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class SectionExam
{
    public int Id { get; set; }

    public int SectionId { get; set; }

    public string ExamTypeCode { get; set; } = null!;

    public string TitleEs { get; set; } = null!;

    public string? TitleEn { get; set; }

    public string? SummaryEs { get; set; }

    public string? SummaryEn { get; set; }

    public string? SourceRef { get; set; }

    public virtual ICollection<ExamStep> ExamSteps { get; set; } = new List<ExamStep>();

    public virtual ExamType ExamTypeCodeNavigation { get; set; } = null!;

    public virtual BodySection Section { get; set; } = null!;
}
