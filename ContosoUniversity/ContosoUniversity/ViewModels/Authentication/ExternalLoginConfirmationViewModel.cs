using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.ViewModels.Authentication
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}