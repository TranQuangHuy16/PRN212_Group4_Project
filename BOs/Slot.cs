using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class Slot
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SlotId { get; set; }

        [Required, StringLength(50)]
        public string SlotName { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public byte Status { get; set; }

        // Relationship: One-to-Many with Schedule
        public ICollection<Schedule> Schedules { get; set; }
    }
}
