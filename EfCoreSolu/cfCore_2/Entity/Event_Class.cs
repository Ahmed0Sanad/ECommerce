using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.Entity
{
    internal class Event_Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Event_Type Categeory { get; set; }

        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Visibility Visibility { get; set; }
        public int ViewerNum { get; set; }
        public int TotalMoney { get; set; }
        public int ParticipantsNumb { get; set; }
        public DateTime SoldOut { get; set; }
        public string place {  get; set; }
        public string Url { get; set; }
        public Payment Payment { get; set; }
        [ForeignKey("Org")]
        public int OrgId { get; set; }
        public User Org { get; set; }
        public ICollection< Tickett>    ticketts { get; set; }

    }
    public enum Event_Type 
    { 
        Trip,confrence,party
    
    }
    public enum Visibility
    {
        publicOnSite,PublicOnly,Privte
    }
    public enum Payment { VodafoneCash,Visa,InstaPay}
}
