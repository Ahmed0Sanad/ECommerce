using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.Entity
{
    internal class Tickett
    {
        [Key]
        public int Id { get; set; }
        public DateTime SubscriptionTime { get; set; }

        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }
        [ForeignKey("Event_Class")]
        public int eventId { get; set; }
        public Event_Class Event_Class { get; set; }
    }
}
