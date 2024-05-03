using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class StudentDegree
{
    public int StudentDegreeId { get; set; }

    public int SubjectClassId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public int DegreeTypeId { get; set; }

    public decimal? StudentDegreeValue { get; set; }

    public string? StudentDegreenote { get; set; }

    public virtual DegreeType DegreeType { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual SubjectClass SubjectClass { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
