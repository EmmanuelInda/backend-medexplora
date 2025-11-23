using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class ExamStep
{
    public int Id { get; set; }

    public int SectionExamId { get; set; }

    public int StepOrder { get; set; }

    public string LabelEs { get; set; } = null!;

    public string? DetailEs { get; set; }

    public string? LabelEn { get; set; }

    public string? DetailEn { get; set; }

    public virtual SectionExam SectionExam { get; set; } = null!;
}
