using System.ComponentModel.DataAnnotations;

namespace Pdsl.Api.ViewModels
{
    public class VerifyCodeVisitorViewModel : VisitorViewModel
    {
        [Required, MaxLength(10)]
        public string? Code { get; set; }
    }
}
