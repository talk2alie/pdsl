using System.ComponentModel.DataAnnotations;

namespace Pdsl.Bff.Models
{
    public class ReleaseInputViewModel
    {
        public string? Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required, Display(Name = "Title Image")]
        public IFormFile BannerImage { get; set; }
        [Required]
        public IFormFile Document { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
        public string UploaderId { get; set; } = string.Empty;
    }
}
