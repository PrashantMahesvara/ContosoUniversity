using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Web.Models
{
    public abstract class Person
        {
            public int Id { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
            [Column("FirstName")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Column("MiddleName")]
            [Display(Name = "Last Name")]
            public string MiddleName { get; set; }



            [Display(Name = "Full Name")]
                public string FullName
                {
                    get
                    {
                        return FirstName + ", " + LastName;
                    }
                }
    }   
}