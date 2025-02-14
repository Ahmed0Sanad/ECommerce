using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffould_test.Models;

[Index("EventId", Name = "IX_Ticketets_eventId")]
[Index("UserId", Name = "IX_Ticketets_userId")]
public partial class Ticketet
{
    [Key]
    public int Id { get; set; }

    public DateTime SubscriptionTime { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("eventId")]
    public int EventId { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("Ticketets")]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Ticketets")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("TickettId")]
    [InverseProperty("Ticketts")]
    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
}
