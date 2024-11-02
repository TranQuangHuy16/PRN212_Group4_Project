using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BOs
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; }


        public byte Status { get; set; }

        // Relationship: One-to-Many with Schedule
        //public ICollection<Schedule> Schedules { get; set; }

        // Relationship: Many-to-Many with Semester through CourseSemester
        public ICollection<CourseSemester> CourseSemesters { get; set; }

        public override string ToString()
        {
            return CourseName;
        }
    }
}
