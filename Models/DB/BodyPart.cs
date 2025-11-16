using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class BodyPart
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Slug { get; set; } = null!;

    public string NameEs { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string? DescriptionEs { get; set; }

    public string? DescriptionEn { get; set; }

    public string? Side { get; set; }

    public string? Sex { get; set; }

    public string? SystemCode { get; set; }

    public string? RegionCode { get; set; }

    public int ModelId { get; set; }

    public string? MeshKey { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsVisible { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Hotspot> Hotspots { get; set; } = new List<Hotspot>();

    public virtual ICollection<BodyPart> InverseParent { get; set; } = new List<BodyPart>();

    public virtual ICollection<MediaAsset> MediaAssets { get; set; } = new List<MediaAsset>();

    public virtual Model Model { get; set; } = null!;

    public virtual BodyPart? Parent { get; set; }

    public virtual Region? RegionCodeNavigation { get; set; }

    public virtual ICollection<RelatedPart> RelatedPartSourceParts { get; set; } = new List<RelatedPart>();

    public virtual ICollection<RelatedPart> RelatedPartTargetParts { get; set; } = new List<RelatedPart>();

    public virtual ICollection<Synonym> Synonyms { get; set; } = new List<Synonym>();

    public virtual System? SystemCodeNavigation { get; set; }
}
