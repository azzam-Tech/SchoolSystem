using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class ClassTimeTable
{
    [Key]
    public int ClassTimeTableId { get; set; }

    public int ClassId { get; set; }

    [StringLength(50)]
    public string? TheDay { get; set; }

    [StringLength(50)]
    public string? PeriodOne { get; set; }

    [StringLength(50)]
    public string? PeriodTow { get; set; }

    [StringLength(50)]
    public string? PeriodThree { get; set; }

    [StringLength(50)]
    public string? PeriodFour { get; set; }

    [StringLength(50)]
    public string? PeriodFive { get; set; }

    [StringLength(50)]
    public string? PeriodSix { get; set; }

    [StringLength(50)]
    public string? PeriodSeven { get; set; }

    [StringLength(50)]
    public string? PeriodEight { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("ClassTimeTables")]
    public virtual Class Class { get; set; } = null!;
}
