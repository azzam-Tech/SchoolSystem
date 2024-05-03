using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

[Keyless]
public partial class VteacherEvalution
{
    [StringLength(100)]
    public string TeacherName { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal TeacherEvaluationValueOne { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal TeacherEvaluationValueTow { get; set; }
}
