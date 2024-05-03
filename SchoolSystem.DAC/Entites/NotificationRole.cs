using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class NotificationRole
{
    [Key]
    public int NotificationRoleId { get; set; }

    public int NotificationId { get; set; }

    public int RoleId { get; set; }

    [ForeignKey("NotificationId")]
    [InverseProperty("NotificationRoles")]
    public virtual Notification Notification { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("NotificationRoles")]
    public virtual Role Role { get; set; } = null!;
}
