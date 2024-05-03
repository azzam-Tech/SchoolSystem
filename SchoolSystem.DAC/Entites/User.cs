using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public int RoleId { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(20)]
    public string? Usernumber { get; set; }

    [StringLength(50)]
    public string Userpassword { get; set; } = null!;

    public string? UserImage { get; set; }

    public bool IsSupervisor { get; set; }

    [InverseProperty("ClassSopervisorNavigation")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("User")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("ReceverNavigation")]
    public virtual ICollection<ParentSubervaisorChat> ParentSubervaisorChatReceverNavigations { get; set; } = new List<ParentSubervaisorChat>();

    [InverseProperty("SenderNavigation")]
    public virtual ICollection<ParentSubervaisorChat> ParentSubervaisorChatSenderNavigations { get; set; } = new List<ParentSubervaisorChat>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("StedentParentNavigation")]
    public virtual ICollection<Student> StudentStedentParentNavigations { get; set; } = new List<Student>();

    [InverseProperty("User")]
    public virtual ICollection<Student> StudentUsers { get; set; } = new List<Student>();

    [InverseProperty("SubjectTeacherNavigation")]
    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();

    [InverseProperty("User")]
    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    [InverseProperty("User")]
    public virtual ICollection<TeacherEvaluation> TeacherEvaluations { get; set; } = new List<TeacherEvaluation>();

    [InverseProperty("User")]
    public virtual ICollection<TeacherTable> TeacherTables { get; set; } = new List<TeacherTable>();

    [InverseProperty("User")]
    public virtual ICollection<TeacherTimeTable> TeacherTimeTables { get; set; } = new List<TeacherTimeTable>();
}
