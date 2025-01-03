using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models;

public partial class AspNetRole
{
    [MaxLength(255)]
    public string Id { get; set; } = null!;

    public string? ConcurrencyStamp { get; set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    [MaxLength(255)]
    public string? NormalizedName { get; set; }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
