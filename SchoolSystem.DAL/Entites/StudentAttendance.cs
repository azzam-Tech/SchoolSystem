using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class StudentAttendance
{
    public int StudentAttendanceId { get; set; }

    public int StudentId { get; set; }

    public int TermId { get; set; }

    public bool StudentAttendanceValue { get; set; }

    public DateTime StudentAttendanceDate { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
