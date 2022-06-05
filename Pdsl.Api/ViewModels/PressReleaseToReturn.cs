namespace Pdsl.Api.ViewModels
{
    /// <summary>
    /// Encapsulates a Press Release for UI display
    /// </summary>
    public class PressReleaseToReturn
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Press Release
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of the Press Release
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the Press Release
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a URL that is the physical location of the Press Release
        /// </summary>
        public string DocumentFileUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a URL that is the physical location of an image to be used
        /// as a thumbnail when the Press Release is displayed in the UI
        /// </summary>
        public string BannerImageFileUrl { get; set; } = string.Empty;

        /// <summary>
        /// The universal date and time at which the Press Release is to be made public
        /// </summary>
        public DateTime ReleaseDateTimeUtc { get; set; }
    }
}
