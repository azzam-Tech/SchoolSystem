using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class StudentAttendance
{
    [Key]
    public int StudentAttendanceId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public bool StudentAttendanceValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StudentAttendanceDate { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentAttendances")]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey("TermId")]
    [InverseProperty("StudentAttendances")]
    public virtual Term Term { get; set; } = null!;
}
