using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class TeacherAnswer
{
    public int TeacherAnswerId { get; set; }

    public int StudentQeustionId { get; set; }

    public string? TeacherAnswerText { get; set; }

    public string? TeacherAnswerImage { get; set; }

    public DateTime? TeacherAnswerDate { get; set; }

    public virtual StudentQeustion StudentQeustion { get; set; } = null!;
}
