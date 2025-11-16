using System;

namespace MedExploraAPI.DTO
{
    public class HotspotCreateDTO
    {
        public int BodyPartId { get; set; }
        public int ModelId { get; set; }
        public string MeshName { get; set; } = null!;
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
    }
}
