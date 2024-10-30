using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }
        public int SemesterId { get; set; }

        [ForeignKey(nameof(CourseId) + "," + nameof(SemesterId))]
        public CourseSemester CourseSemester { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [ForeignKey("Account")]
        public int ?AccountId { get; set; }
        public Account ?Account { get; set; }

        [ForeignKey("Slot")]
        public int SlotId { get; set; }
        public Slot Slot { get; set; }

        public DateTime ScheduleDate { get; set; }

        public byte Status { get; set; }
    }
}
