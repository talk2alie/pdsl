using Ardalis.GuardClauses;
using Pdsl.Api.GauardClauseExtensions;

namespace Pdsl.Api.PressReleases
{
    public class PressRelease
    {
        private Guid id;
        public Guid Id 
        { 
            get { return id; }
            set { id = Guard.Against.InvalidPressReleaseId(value, nameof(Id)); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = Guard.Against.InvalidPressReleaseTitle(value, nameof(Title)); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = Guard.Against.InvalidPressReleaseDescription(value, nameof(Description));}
        }

        private string documentFilePath;
        public string DocumentFilePath
        {
            get { return documentFilePath; }
            set { documentFilePath = Guard.Against.NullOrWhiteSpace(value, nameof(DocumentFilePath)); }
        }

        private string bannerImageFilePath;
        public string BannerImageFilePath
        {
            get { return bannerImageFilePath; }
            set { bannerImageFilePath = Guard.Against.NullOrWhiteSpace(value, nameof(BannerImageFilePath)); }
        }

        private DateTime releaseDateTimeUtc;
        public DateTime ReleaseDateTimeUtc
        {
            get { return releaseDateTimeUtc; }
            set { releaseDateTimeUtc = Guard.Against.InvalidPressReleaseReleaseDate(value, nameof(ReleaseDateTimeUtc)); }
        }

        private string uploaderId;
        public string UploaderId
        {
            get { return uploaderId; }
            set { uploaderId = Guard.Against.NullOrWhiteSpace(value, nameof(UploaderId)); }
        }

        public DateTime CreationDateTimeUtc { get; private set; }

        public DateTime LastUpdatedDateTimeUtc { get; private set; }

        public PressRelease(Guid id
            , string title
            , string description
            , string documentFilePath
            , string bannerImageFilePath
            , DateTime releaseDate
            , string uploaderId)
        {
            this.id = Guard.Against.InvalidPressReleaseId(id, nameof(Id));
            this.title = Guard.Against.InvalidPressReleaseTitle(title, nameof(Title));
            this.description = Guard.Against.InvalidPressReleaseDescription(description, nameof(Description));
            this.documentFilePath = Guard.Against.NullOrWhiteSpace(documentFilePath, nameof(DocumentFilePath)); ;
            this.bannerImageFilePath = Guard.Against.NullOrWhiteSpace(bannerImageFilePath, nameof(BannerImageFilePath)); ;
            this.uploaderId = Guard.Against.NullOrWhiteSpace(uploaderId, nameof(UploaderId));
            this.releaseDateTimeUtc = Guard.Against.InvalidPressReleaseReleaseDate(releaseDate, nameof(ReleaseDateTimeUtc));
            CreationDateTimeUtc = DateTime.UtcNow;
            LastUpdatedDateTimeUtc = DateTime.UtcNow;
        }

        public PressRelease(string title
            , string description
            , string documentFilePath
            , string bannerImageFilePath
            , DateTime releaseDate
            , string uploaderId) : this(Guid.NewGuid()
                , title
                , description
                , documentFilePath
                , bannerImageFilePath
                , releaseDate
                , uploaderId)
        {

        }
    }
}
    