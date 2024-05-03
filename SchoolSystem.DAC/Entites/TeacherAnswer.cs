using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class TeacherAnswer
{
    [Key]
    public int TeacherAnswerId { get; set; }

    public int StudentQeustionId { get; set; }

    public string? TeacherAnswerText { get; set; }

    public string? TeacherAnswerImage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TeacherAnswerDate { get; set; }

    [ForeignKey("StudentQeustionId")]
    [InverseProperty("TeacherAnswers")]
    public virtual StudentQeustion StudentQeustion { get; set; } = null!;
}
