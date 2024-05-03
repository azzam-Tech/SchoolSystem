using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class TeacherTimeTable
{
    public int TeacherTimeTableId { get; set; }

    public int UserId { get; set; }

    public string TeacherTimeTableImage { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
