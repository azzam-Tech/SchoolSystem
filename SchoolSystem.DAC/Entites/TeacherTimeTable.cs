using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class TeacherTimeTable
{
    [Key]
    public int TeacherTimeTableId { get; set; }

    public int UserId { get; set; }

    public string TeacherTimeTableImage { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("TeacherTimeTables")]
    public virtual User User { get; set; } = null!;
}
