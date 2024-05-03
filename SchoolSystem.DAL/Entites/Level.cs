using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Level
{
    public int LevelId { get; set; }

    public int DepartmentId { get; set; }

    public string LevelName { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
