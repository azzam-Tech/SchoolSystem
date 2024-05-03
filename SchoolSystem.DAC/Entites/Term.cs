using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Term
{
    [Key]
    public int TermId { get; set; }

    [StringLength(50)]
    public string TermName { get; set; } = null!;

    [InverseProperty("Term")]
    public virtual ICollection<DegreeFile> DegreeFiles { get; set; } = new List<DegreeFile>();

    [InverseProperty("Term")]
    public virtual ICollection<FollowUpNoteBook> FollowUpNoteBooks { get; set; } = new List<FollowUpNoteBook>();

    [InverseProperty("Term")]
    public virtual ICollection<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    [InverseProperty("Term")]
    public virtual ICollection<Reinforcementlesson> Reinforcementlessons { get; set; } = new List<Reinforcementlesson>();

    [InverseProperty("Term")]
    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    [InverseProperty("Term")]
    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();

    [InverseProperty("Term")]
    public virtual ICollection<StudentQeustion> StudentQeustions { get; set; } = new List<StudentQeustion>();
}
