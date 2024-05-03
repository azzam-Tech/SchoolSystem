using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class SubervisorNotification
{
    public int SubervisorNotificationId { get; set; }

    public int NotificationId { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Notification Notification { get; set; } = null!;
}
