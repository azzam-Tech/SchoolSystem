using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class SubervisorNotification
{
    [Key]
    public int SubervisorNotificationId { get; set; }

    public int NotificationId { get; set; }

    public int ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("SubervisorNotifications")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("NotificationId")]
    [InverseProperty("SubervisorNotifications")]
    public virtual Notification Notification { get; set; } = null!;
}
