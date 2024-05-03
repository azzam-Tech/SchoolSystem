using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class StudentTimeTable
{
    [Key]
    public int StudentTimeTableId { get; set; }

    public int Classid { get; set; }

    public string StudentTimeTableImage { get; set; } = null!;

    [ForeignKey("Classid")]
    [InverseProperty("StudentTimeTables")]
    public virtual Class Class { get; set; } = null!;
}
