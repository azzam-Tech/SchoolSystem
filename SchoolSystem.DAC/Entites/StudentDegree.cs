using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class StudentDegree
{
    [Key]
    public int StudentDegreeId { get; set; }

    public int SubjectClassId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public int DegreeTypeId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? StudentDegreeValue { get; set; }

    public string? StudentDegreenote { get; set; }

    [ForeignKey("DegreeTypeId")]
    [InverseProperty("StudentDegrees")]
    public virtual DegreeType DegreeType { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentDegrees")]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey("SubjectClassId")]
    [InverseProperty("StudentDegrees")]
    public virtual SubjectClass SubjectClass { get; set; } = null!;

    [ForeignKey("TermId")]
    [InverseProperty("StudentDegrees")]
    public virtual Term Term { get; set; } = null!;
}
