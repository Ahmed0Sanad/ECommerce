using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.Entity
{
    internal class PrivateQuestion
    {
        public string Question {  get; set; }

        [ForeignKey("Event_Class")]
        public int eventId { get; set; }
        public Event_Class Event_Class { get; set; }
    }
}
