using System.ComponentModel.DataAnnotations;

namespace Pdsl.Api.ViewModels
{
    public class UserViewModel
    {
        [Required, MaxLength(255)]
        public string? FullName { get; set; }

        [Required, MaxLength(255)]
        public string? Organization { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
