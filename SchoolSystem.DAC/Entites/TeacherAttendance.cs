using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class TeacherAttendance
{
    [Key]
    public int TeacherAttendanceId { get; set; }

    public int UserId { get; set; }

    public bool TeacherAttendanceValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TeacherAttendanceDate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("TeacherAttendances")]
    public virtual User User { get; set; } = null!;
}
