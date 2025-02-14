using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.Entity
{
    internal class Features
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int ParticipateNumber { get; set; }
        public int limit { get; set; }
        [ForeignKey("Event_Class")]
        public int eventId { get; set; }
        public Event_Class Event_Class { get; set; }

    }
}
