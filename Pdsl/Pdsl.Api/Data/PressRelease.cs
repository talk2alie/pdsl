namespace Pdsl.Api.Data
{
    public class PressRelease
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? HeroImageFilePath { get; set; }
        public string? DataFilePath { get; set; }
        public string? LocatorId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UploadDate { get; set; }
        public int? UploaderId { get; set; }
        public Employee? Uploader { get; set; }
    }
}