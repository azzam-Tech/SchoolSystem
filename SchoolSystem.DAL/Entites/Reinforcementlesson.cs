using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Reinforcementlesson
{
    public int ReinforcementlessonId { get; set; }

    public int SubjectClassId { get; set; }

    public int TermId { get; set; }

    public string ReinforcementlessonTitle { get; set; } = null!;

    public string? Reinforcementlessondescription { get; set; }

    public string? ReinforcementlessonFile { get; set; }

    public string? Reinforcementlessonlink { get; set; }

    public DateTime? ReinforcementlessonDate { get; set; }

    public virtual SubjectClass SubjectClass { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
