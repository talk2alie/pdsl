using System.ComponentModel.DataAnnotations;

namespace Pdsl.Api.ViewModels
{
    /// <summary>
    /// Encapsulates an existing Press Release in need of an edit
    /// </summary>
    public class PressReleaseToEdit
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Press Release
        /// </summary>
        [Required]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the Press Release
        /// </summary>
        [Required, MinLength(10), MaxLength(255)]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the Press Release
        /// </summary>
        [Required, MinLength(100), MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the .pdf document of the Press Release
        /// </summary>
        [Required]
        public IFormFile? Document { get; set; }

        /// <summary>
        /// Gets or sets an image that will be used as a thumbnail of the Press Release
        /// </summary>
        [Required]
        public IFormFile? BannerImage { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the staff who uploaded the Press Release
        /// </summary>
        [Required]
        public string? UploaderId { get; set; }

        /// <summary>
        /// The universal date and time at which the Press Release is to be made public
        /// </summary>
        public DateTime ReleaseDateTimeUtc { get; set; }
    }
}
