using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOs
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        public byte Status { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        public int Role { get; set; }

        // Relationship: One-to-Many with Schedule
        public ICollection<Schedule> Schedules { get; set; }
    }
}
