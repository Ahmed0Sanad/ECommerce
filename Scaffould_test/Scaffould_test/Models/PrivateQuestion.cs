using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffould_test.Models;

[PrimaryKey("EventId", "Question")]
public partial class PrivateQuestion
{
    [Key]
    public string Question { get; set; } = null!;

    [Key]
    [Column("eventId")]
    public int EventId { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("PrivateQuestions")]
    public virtual Event Event { get; set; } = null!;
}
