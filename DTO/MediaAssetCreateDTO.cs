using System;

namespace MedExploraAPI.DTO
{
    public class MediaAssetCreateDTO
    {
        public int BodyPartId { get; set; }
        public string Type { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? CaptionEs { get; set; }
        public string? CaptionEn { get; set; }
        public string? Attribution { get; set; }
        public string? License { get; set; }
    }
}
