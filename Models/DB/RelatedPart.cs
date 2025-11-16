using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class RelatedPart
{
    public int Id { get; set; }

    public int SourcePartId { get; set; }

    public int TargetPartId { get; set; }

    public string RelationType { get; set; } = null!;

    public virtual BodyPart SourcePart { get; set; } = null!;

    public virtual BodyPart TargetPart { get; set; } = null!;
}
