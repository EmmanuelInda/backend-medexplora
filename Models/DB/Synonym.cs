using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class Synonym
{
    public int Id { get; set; }

    public int BodyPartId { get; set; }

    public string Lang { get; set; } = null!;

    public string Term { get; set; } = null!;

    public virtual BodyPart BodyPart { get; set; } = null!;
}
