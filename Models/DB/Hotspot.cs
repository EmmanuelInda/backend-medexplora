using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class Hotspot
{
    public int Id { get; set; }

    public int BodyPartId { get; set; }

    public int ModelId { get; set; }

    public string MeshName { get; set; } = null!;

    public double? X { get; set; }

    public double? Y { get; set; }

    public double? Z { get; set; }

    public virtual BodyPart BodyPart { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;
}
