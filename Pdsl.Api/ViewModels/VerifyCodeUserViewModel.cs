using System.ComponentModel.DataAnnotations;

namespace Pdsl.Api.ViewModels
{
    public class VerifyCodeUserViewModel : UserViewModel
    {
        [Required, MaxLength(10)]
        public string? Code { get; set; }
    }
}
