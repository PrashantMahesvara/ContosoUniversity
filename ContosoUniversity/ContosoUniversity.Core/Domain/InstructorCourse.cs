using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Core.Domain
{
    public class InstructorCourse
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}