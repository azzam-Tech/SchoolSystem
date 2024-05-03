using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<NotificationRole> NotificationRoles { get; set; } = new List<NotificationRole>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
