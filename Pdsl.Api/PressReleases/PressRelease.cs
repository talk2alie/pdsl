using Ardalis.GuardClauses;
using Pdsl.Api.GauardClauseExtensions;

namespace Pdsl.Api.PressReleases
{
    public class PressRelease
    {
        private Guid id;
        public Guid Id 
        { get { return id; } 
          set
            {
                Guard.Against.InvalidPressReleaseId(value, nameof(id));
                id = value;
            }
        }

        private string title;
        public string Title
        {
            get { return title; }

        }

        public string Description { get; set; }

        public string DocumentFilePath { get; set; }

        public string BannerImageFilePath { get; set; }

        public DateTime ReleaseDateTimeUtc { get; set; }

        public string UploaderId { get; set; }

        public DateTime CreationDateTimeUtc { get; set; }

        public DateTime LastUpdatedDateTimeUtc { get; set; }

        public PressRelease(Guid id
            , string title
            , string description
            , string documentFilePath
            , string bannerImageFilePath
            , DateTime releaseDate
            , string uploaderId)
        {
            Id = id;
            Title = title;
            Description = description;
            DocumentFilePath = documentFilePath;
            BannerImageFilePath = bannerImageFilePath;
            ReleaseDateTimeUtc = releaseDate.ToUniversalTime();
            UploaderId = uploaderId;
            CreationDateTimeUtc = DateTime.UtcNow;
            LastUpdatedDateTimeUtc = DateTime.UtcNow;
        }
    }
}
    