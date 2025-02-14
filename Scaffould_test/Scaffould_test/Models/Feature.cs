using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffould_test.Models;

[Index("EventId", Name = "IX_Features_eventId")]
public partial class Feature
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("price")]
    public int Price { get; set; }

    public int ParticipateNumber { get; set; }

    [Column("limit")]
    public int Limit { get; set; }

    [Column("eventId")]
    public int EventId { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("Features")]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey("FeatureId")]
    [InverseProperty("Features")]
    public virtual ICollection<Ticketet> Ticketts { get; set; } = new List<Ticketet>();
}
