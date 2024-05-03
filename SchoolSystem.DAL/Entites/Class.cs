using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Class
{
    public int ClassId { get; set; }

    public int LevelId { get; set; }

    public int ClassSopervisor { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<ClassChat> ClassChats { get; set; } = new List<ClassChat>();

    public virtual User ClassSopervisorNavigation { get; set; } = null!;

    public virtual ICollection<ClassTimeTable> ClassTimeTables { get; set; } = new List<ClassTimeTable>();

    public virtual ICollection<FollowUpNoteBook> FollowUpNoteBooks { get; set; } = new List<FollowUpNoteBook>();

    public virtual Level Level { get; set; } = null!;

    public virtual ICollection<StudentSuggestion> StudentSuggestions { get; set; } = new List<StudentSuggestion>();

    public virtual ICollection<StudentTimeTable> StudentTimeTables { get; set; } = new List<StudentTimeTable>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<SubervisorNotification> SubervisorNotifications { get; set; } = new List<SubervisorNotification>();

    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();
}
