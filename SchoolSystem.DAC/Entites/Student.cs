using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public int StedentParent { get; set; }

    public int ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class Class { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<ClassChat> ClassChats { get; set; } = new List<ClassChat>();

    [InverseProperty("Student")]
    public virtual ICollection<DegreeFile> DegreeFiles { get; set; } = new List<DegreeFile>();

    [InverseProperty("Student")]
    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    [ForeignKey("StedentParent")]
    [InverseProperty("StudentStedentParentNavigations")]
    public virtual User StedentParentNavigation { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentQeustion> StudentQeustions { get; set; } = new List<StudentQeustion>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentSuggestion> StudentSuggestions { get; set; } = new List<StudentSuggestion>();

    [ForeignKey("UserId")]
    [InverseProperty("StudentUsers")]
    public virtual User User { get; set; } = null!;
}
