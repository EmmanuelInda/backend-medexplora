using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class Region
{
    public string Code { get; set; } = null!;

    public string NameEs { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public virtual ICollection<BodyPart> BodyParts { get; set; } = new List<BodyPart>();
}
