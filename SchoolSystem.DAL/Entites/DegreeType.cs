using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class DegreeType
{
    public int DegreeTypeId { get; set; }

    public string DegreeTypeName { get; set; } = null!;

    public virtual ICollection<DegreeFile> DegreeFiles { get; set; } = new List<DegreeFile>();

    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();
}
