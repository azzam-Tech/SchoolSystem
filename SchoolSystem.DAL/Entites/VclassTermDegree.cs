using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class VclassTermDegree
{
    public string StudentName { get; set; } = null!;

    public string ClassName { get; set; } = null!;

    public decimal? TotalMarks { get; set; }

    public string TermName { get; set; } = null!;
}
