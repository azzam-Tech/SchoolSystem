using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Usernumber { get; set; }

    public string Userpassword { get; set; } = null!;

    public string? UserImage { get; set; }

    public bool IsSupervisor { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<ParentSubervaisorChat> ParentSubervaisorChatReceverNavigations { get; set; } = new List<ParentSubervaisorChat>();

    public virtual ICollection<ParentSubervaisorChat> ParentSubervaisorChatSenderNavigations { get; set; } = new List<ParentSubervaisorChat>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Student> StudentStedentParentNavigations { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentUsers { get; set; } = new List<Student>();

    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();

    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    public virtual ICollection<TeacherEvaluation> TeacherEvaluations { get; set; } = new List<TeacherEvaluation>();

    public virtual ICollection<TeacherTable> TeacherTables { get; set; } = new List<TeacherTable>();

    public virtual ICollection<TeacherTimeTable> TeacherTimeTables { get; set; } = new List<TeacherTimeTable>();
}
