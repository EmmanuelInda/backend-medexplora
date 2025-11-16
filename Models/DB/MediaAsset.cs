using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class MediaAsset
{
    public int Id { get; set; }

    public int BodyPartId { get; set; }

    public string Type { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string? CaptionEs { get; set; }

    public string? CaptionEn { get; set; }

    public string? Attribution { get; set; }

    public string? License { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BodyPart BodyPart { get; set; } = null!;
}
