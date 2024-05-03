using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();
}
