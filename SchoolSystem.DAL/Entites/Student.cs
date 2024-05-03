using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Student
{
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public int StedentParent { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<ClassChat> ClassChats { get; set; } = new List<ClassChat>();

    public virtual ICollection<DegreeFile> DegreeFiles { get; set; } = new List<DegreeFile>();

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    public virtual User StedentParentNavigation { get; set; } = null!;

    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();

    public virtual ICollection<StudentQeustion> StudentQeustions { get; set; } = new List<StudentQeustion>();

    public virtual ICollection<StudentSuggestion> StudentSuggestions { get; set; } = new List<StudentSuggestion>();

    public virtual User User { get; set; } = null!;
}
