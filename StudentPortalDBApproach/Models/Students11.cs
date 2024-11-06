using System;
using System.Collections.Generic;

namespace StudentPortalDBApproach.Models;

public partial class Students11
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public int Percentage { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
