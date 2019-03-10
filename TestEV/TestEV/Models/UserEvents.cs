using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEV.Models
{
    public class UserEvents
    {
        [Key]
        public int Id_UserEvents { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Event Event { get; set; }
    }
}