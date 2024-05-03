using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public string NotificationTitle { get; set; } = null!;

    public string? NotificationText { get; set; }

    public string? NotificationImagePath { get; set; }

    public DateTime? NotificationDate { get; set; }

    public virtual ICollection<NotificationRole> NotificationRoles { get; set; } = new List<NotificationRole>();

    public virtual ICollection<SubervisorNotification> SubervisorNotifications { get; set; } = new List<SubervisorNotification>();

    public virtual ICollection<TeacherNotification> TeacherNotifications { get; set; } = new List<TeacherNotification>();

    public virtual User User { get; set; } = null!;
}
