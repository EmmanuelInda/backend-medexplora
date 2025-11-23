using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class ExamType
{
    public string Code { get; set; } = null!;

    public string NameEs { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public int? SortOrder { get; set; }

    public virtual ICollection<SectionExam> SectionExams { get; set; } = new List<SectionExam>();
}
