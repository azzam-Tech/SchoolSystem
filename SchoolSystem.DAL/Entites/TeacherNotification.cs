using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class TeacherNotification
{
    public int TeacherNotificationId { get; set; }

    public int NotificationId { get; set; }

    public int SubjectClassId { get; set; }

    public virtual Notification Notification { get; set; } = null!;

    public virtual SubjectClass SubjectClass { get; set; } = null!;
}
