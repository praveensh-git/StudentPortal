using System;
using System.Collections.Generic;

namespace StudentPortalDBApproach.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public int Percentage { get; set; }

    public virtual ICollection<Students11> Students11s { get; set; } = new List<Students11>();
}
