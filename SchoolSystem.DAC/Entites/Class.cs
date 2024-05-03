using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Class
{
    [Key]
    public int ClassId { get; set; }

    public int LevelId { get; set; }

    public int ClassSopervisor { get; set; }

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<ClassChat> ClassChats { get; set; } = new List<ClassChat>();

    [ForeignKey("ClassSopervisor")]
    [InverseProperty("Classes")]
    public virtual User ClassSopervisorNavigation { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<ClassTimeTable> ClassTimeTables { get; set; } = new List<ClassTimeTable>();

    [InverseProperty("Class")]
    public virtual ICollection<FollowUpNoteBook> FollowUpNoteBooks { get; set; } = new List<FollowUpNoteBook>();

    [ForeignKey("LevelId")]
    [InverseProperty("Classes")]
    public virtual Level Level { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<StudentSuggestion> StudentSuggestions { get; set; } = new List<StudentSuggestion>();

    [InverseProperty("Class")]
    public virtual ICollection<StudentTimeTable> StudentTimeTables { get; set; } = new List<StudentTimeTable>();

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Class")]
    public virtual ICollection<SubervisorNotification> SubervisorNotifications { get; set; } = new List<SubervisorNotification>();

    [InverseProperty("Class")]
    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();
}
