using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Solution
{
    [Key]
    public int SolutionId { get; set; }

    public int HomeWorkId { get; set; }

    public int StudentId { get; set; }

    public string? SolutionImage { get; set; }

    public string? SolutionFile { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SolutionDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SolutionDegree { get; set; }

    public string? Solutionnote { get; set; }

    [ForeignKey("HomeWorkId")]
    [InverseProperty("Solutions")]
    public virtual HomeWork HomeWork { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Solutions")]
    public virtual Student Student { get; set; } = null!;
}
