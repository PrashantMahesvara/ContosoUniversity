using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityContosoUniversity
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}