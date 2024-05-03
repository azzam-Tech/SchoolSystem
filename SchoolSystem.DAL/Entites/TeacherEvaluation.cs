using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class TeacherEvaluation
{
    public int TeacherEvaluationId { get; set; }

    public int UserId { get; set; }

    public decimal TeacherEvaluationValueOne { get; set; }

    public decimal TeacherEvaluationValueTow { get; set; }

    public virtual User User { get; set; } = null!;
}
