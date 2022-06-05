using System.ComponentModel.DataAnnotations;

namespace Pdsl.Api.ViewModels
{
    public class PressReleaseToDeactivate
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Press Release
        /// </summary>
        [Required]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the deactivator of the Press Release
        /// </summary>
        [Required]
        public string? DeactivatedById { get; set; }
    }
}
