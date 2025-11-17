namespace MedExploraAPI.DTO
{
    public class SystemCreateDTO
    {
        public required string Code { get; set; }
        public required string NameEs { get; set; }
        public required string NameEn { get; set; }
    }

    public class SystemDTO
    {
        public string Code { get; set; }
        public string NameEs { get; set; }
        public string NameEn { get; set; }
    }
}