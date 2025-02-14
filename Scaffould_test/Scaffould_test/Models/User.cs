using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Scaffould_test.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Column("FName")]
    public string Fname { get; set; } = null!;

    [Column("LName")]
    public string Lname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    [Column("role")]
    public int Role { get; set; }

    public string Phone { get; set; } = null!;

    [InverseProperty("Org")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    [InverseProperty("User")]
    public virtual ICollection<Ticketet> Ticketets { get; set; } = new List<Ticketet>();
}
