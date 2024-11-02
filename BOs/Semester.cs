using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class Semester
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SemesterId { get; set; }

        [Required, StringLength(50)]
        public string SemesterName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte Status { get; set; }

        // Relationship: Many-to-Many with Course through CourseSemester
        public ICollection<CourseSemester> CourseSemesters { get; set; }

        public override string ToString()
        {
            return SemesterName + " - " + StartDate + " - " + EndDate;
        }
    }
}
