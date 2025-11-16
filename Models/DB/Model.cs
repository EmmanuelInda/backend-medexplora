using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class Model
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? Version { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<BodyPart> BodyParts { get; set; } = new List<BodyPart>();

    public virtual ICollection<Hotspot> Hotspots { get; set; } = new List<Hotspot>();
}
