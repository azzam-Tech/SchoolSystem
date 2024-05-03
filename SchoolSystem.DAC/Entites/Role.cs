using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<NotificationRole> NotificationRoles { get; set; } = new List<NotificationRole>();

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
