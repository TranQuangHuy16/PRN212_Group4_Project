using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [Required, StringLength(50)]
        public string RoomName { get; set; }

        public byte Status { get; set; }

        // Relationship: One-to-Many with Schedule
        public ICollection<Schedule> Schedules { get; set; }

        public override string ToString()
        {
            return RoomName;
        }
    }
}
