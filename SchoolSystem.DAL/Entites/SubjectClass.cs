using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class SubjectClass
{
    public int SubjectClassId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int SubjectTeacher { get; set; }

    public string SubjectClassName { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<FollowUpNoteBook> FollowUpNoteBooks { get; set; } = new List<FollowUpNoteBook>();

    public virtual ICollection<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    public virtual ICollection<Reinforcementlesson> Reinforcementlessons { get; set; } = new List<Reinforcementlesson>();

    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();

    public virtual ICollection<StudentQeustion> StudentQeustions { get; set; } = new List<StudentQeustion>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual User SubjectTeacherNavigation { get; set; } = null!;

    public virtual ICollection<TeacherNotification> TeacherNotifications { get; set; } = new List<TeacherNotification>();
}
