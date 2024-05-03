using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class TeacherEvaluation
{
    [Key]
    public int TeacherEvaluationId { get; set; }

    public int UserId { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal TeacherEvaluationValueOne { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal TeacherEvaluationValueTow { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("TeacherEvaluations")]
    public virtual User User { get; set; } = null!;
}
