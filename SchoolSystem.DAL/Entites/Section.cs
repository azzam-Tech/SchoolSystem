using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Section
{
    public int SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public virtual ICollection<LaibaryBook> LaibaryBooks { get; set; } = new List<LaibaryBook>();
}
