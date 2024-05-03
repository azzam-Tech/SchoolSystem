using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class LaibaryBook
{
    public int LaibaryBookId { get; set; }

    public int Sectionid { get; set; }

    public string LaibaryBookName { get; set; } = null!;

    public string? LaibaryBookImagePath { get; set; }

    public string LaibaryBookPath { get; set; } = null!;

    public virtual Section Section { get; set; } = null!;
}
