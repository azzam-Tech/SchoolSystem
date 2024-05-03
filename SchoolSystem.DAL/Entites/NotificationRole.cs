using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class NotificationRole
{
    public int NotificationRoleId { get; set; }

    public int NotificationId { get; set; }

    public int RoleId { get; set; }

    public virtual Notification Notification { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
