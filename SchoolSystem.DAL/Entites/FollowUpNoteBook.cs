using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class FollowUpNoteBook
{
    public int FollowUpNoteBookId { get; set; }

    public int SubjectClassId { get; set; }

    public int ClassId { get; set; }

    public int TermId { get; set; }

    public string FollowUpNoteBookText { get; set; } = null!;

    public DateTime FollowUpNoteBookDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual SubjectClass SubjectClass { get; set; } = null!;

    public virtual Term Term { get; set; } = null!;
}
