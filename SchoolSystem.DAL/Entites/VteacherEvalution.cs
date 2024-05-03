using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class VteacherEvalution
{
    public string TeacherName { get; set; } = null!;

    public decimal TeacherEvaluationValueOne { get; set; }

    public decimal TeacherEvaluationValueTow { get; set; }
}
