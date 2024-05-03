using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Notification
{
    [Key]
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    [StringLength(100)]
    public string NotificationTitle { get; set; } = null!;

    public string? NotificationText { get; set; }

    public string? NotificationImagePath { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NotificationDate { get; set; }

    [InverseProperty("Notification")]
    public virtual ICollection<NotificationRole> NotificationRoles { get; set; } = new List<NotificationRole>();

    [InverseProperty("Notification")]
    public virtual ICollection<SubervisorNotification> SubervisorNotifications { get; set; } = new List<SubervisorNotification>();

    [InverseProperty("Notification")]
    public virtual ICollection<TeacherNotification> TeacherNotifications { get; set; } = new List<TeacherNotification>();

    [ForeignKey("UserId")]
    [InverseProperty("Notifications")]
    public virtual User User { get; set; } = null!;
}
