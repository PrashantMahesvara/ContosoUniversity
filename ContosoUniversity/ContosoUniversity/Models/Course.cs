using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//makes this identifier not auto-updating. Manual Id now required
        [Display(Name = "Course Code")]
        public string Id { get; set; }
        
        public string Title { get; set; }

        [Display(Name = "Punti")]
        [Range(0, 5)]
        public int Credits { get; set; }

        public string Information { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}