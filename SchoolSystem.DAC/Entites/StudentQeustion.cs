using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class StudentQeustion
{
    [Key]
    public int StudentQeustionId { get; set; }

    public int SubjectClassId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public string? StudentQeustionText { get; set; }

    public string? StudentQeustionImage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StudentQeustionDate { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentQeustions")]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey("SubjectClassId")]
    [InverseProperty("StudentQeustions")]
    public virtual SubjectClass SubjectClass { get; set; } = null!;

    [InverseProperty("StudentQeustion")]
    public virtual ICollection<TeacherAnswer> TeacherAnswers { get; set; } = new List<TeacherAnswer>();

    [ForeignKey("TermId")]
    [InverseProperty("StudentQeustions")]
    public virtual Term Term { get; set; } = null!;
}
