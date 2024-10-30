using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class CourseSemester
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Semester")]
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }


        public ICollection<Schedule> Schedules { get; set; }
    }
}
