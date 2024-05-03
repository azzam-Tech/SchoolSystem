using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Term
{
    public int TermId { get; set; }

    public string TermName { get; set; } = null!;

    public virtual ICollection<DegreeFile> DegreeFiles { get; set; } = new List<DegreeFile>();

    public virtual ICollection<FollowUpNoteBook> FollowUpNoteBooks { get; set; } = new List<FollowUpNoteBook>();

    public virtual ICollection<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    public virtual ICollection<Reinforcementlesson> Reinforcementlessons { get; set; } = new List<Reinforcementlesson>();

    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();

    public virtual ICollection<StudentQeustion> StudentQeustions { get; set; } = new List<StudentQeustion>();
}
