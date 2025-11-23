using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class BodySection
{
    public int Id { get; set; }

    public int BodyPartId { get; set; }

    public string Slug { get; set; } = null!;

    public string NameEs { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public int? SortOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual BodyPart BodyPart { get; set; } = null!;

    public virtual ICollection<SectionExam> SectionExams { get; set; } = new List<SectionExam>();
}
