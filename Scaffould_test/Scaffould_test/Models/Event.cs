using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffould_test.Models;

[Index("OrgId", Name = "IX_Events_OrgId")]
public partial class Event
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Categeory { get; set; }

    public string Details { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int Visibility { get; set; }

    public int ViewerNum { get; set; }

    public int TotalMoney { get; set; }

    public int ParticipantsNumb { get; set; }

    public DateTime SoldOut { get; set; }

    [Column("place")]
    public string Place { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int Payment { get; set; }

    public int OrgId { get; set; }

    [InverseProperty("Event")]
    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();

    [ForeignKey("OrgId")]
    [InverseProperty("Events")]
    public virtual User Org { get; set; } = null!;

    [InverseProperty("Event")]
    public virtual ICollection<PrivateQuestion> PrivateQuestions { get; set; } = new List<PrivateQuestion>();

    [InverseProperty("Event")]
    public virtual ICollection<Ticketet> Ticketets { get; set; } = new List<Ticketet>();
}
