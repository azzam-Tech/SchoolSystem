using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class DegreeFile
{
    public int DegreeFileId { get; set; }

    public int TermId { get; set; }

    public int DegreeTypeId { get; set; }

    public int StudentId { get; set; }

    public string DegreeFileName { get; set; } = null!;

    public string DegreeFilePath { get; set; } = null!;

    public virtual DegreeType DegreeType { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
