using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class TeacherNotification
{
    [Key]
    public int TeacherNotificationId { get; set; }

    public int NotificationId { get; set; }

    public int SubjectClassId { get; set; }

    [ForeignKey("NotificationId")]
    [InverseProperty("TeacherNotifications")]
    public virtual Notification Notification { get; set; } = null!;

    [ForeignKey("SubjectClassId")]
    [InverseProperty("TeacherNotifications")]
    public virtual SubjectClass SubjectClass { get; set; } = null!;
}
