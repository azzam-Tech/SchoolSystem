using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Solution
{
    public int SolutionId { get; set; }

    public int HomeWorkId { get; set; }

    public int StudentId { get; set; }

    public string? SolutionImage { get; set; }

    public string? SolutionFile { get; set; }

    public DateTime? SolutionDate { get; set; }

    public decimal? SolutionDegree { get; set; }

    public string? Solutionnote { get; set; }

    public virtual HomeWork HomeWork { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
