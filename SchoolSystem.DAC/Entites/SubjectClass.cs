using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class SubjectClass
{
    [Key]
    public int SubjectClassId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int SubjectTeacher { get; set; }

    [StringLength(50)]
    public string SubjectClassName { get; set; } = null!;

    [ForeignKey("ClassId")]
    [InverseProperty("SubjectClasses")]
    public virtual Class Class { get; set; } = null!;

    [InverseProperty("SubjectClass")]
    public virtual ICollection<FollowUpNoteBook> FollowUpNoteBooks { get; set; } = new List<FollowUpNoteBook>();

    [InverseProperty("SubjectClass")]
    public virtual ICollection<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    [InverseProperty("SubjectClass")]
    public virtual ICollection<Reinforcementlesson> Reinforcementlessons { get; set; } = new List<Reinforcementlesson>();

    [InverseProperty("SubjectClass")]
    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();

    [InverseProperty("SubjectClass")]
    public virtual ICollection<StudentQeustion> StudentQeustions { get; set; } = new List<StudentQeustion>();

    [ForeignKey("SubjectId")]
    [InverseProperty("SubjectClasses")]
    public virtual Subject Subject { get; set; } = null!;

    [ForeignKey("SubjectTeacher")]
    [InverseProperty("SubjectClasses")]
    public virtual User SubjectTeacherNavigation { get; set; } = null!;

    [InverseProperty("SubjectClass")]
    public virtual ICollection<TeacherNotification> TeacherNotifications { get; set; } = new List<TeacherNotification>();
}
