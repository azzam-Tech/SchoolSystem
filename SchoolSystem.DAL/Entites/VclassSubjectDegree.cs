using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class VclassSubjectDegree
{
    public string StudentName { get; set; } = null!;

    public string ClassName { get; set; } = null!;

    public string SubjectClassName { get; set; } = null!;

    public decimal? TotalMarks { get; set; }
}
