using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class StudentTimeTable
{
    public int StudentTimeTableId { get; set; }

    public int Classid { get; set; }

    public string StudentTimeTableImage { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;
}
