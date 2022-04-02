﻿namespace Pdsl.Api.Models
{
    public class Release
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BannerImagePath { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
        public string UploaderId { get; set; } = string.Empty;
    }
}
