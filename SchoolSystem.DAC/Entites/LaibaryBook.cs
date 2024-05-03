using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class LaibaryBook
{
    [Key]
    public int LaibaryBookId { get; set; }

    public int Sectionid { get; set; }

    [StringLength(50)]
    public string LaibaryBookName { get; set; } = null!;

    public string? LaibaryBookImagePath { get; set; }

    public string LaibaryBookPath { get; set; } = null!;

    [ForeignKey("Sectionid")]
    [InverseProperty("LaibaryBooks")]
    public virtual Section Section { get; set; } = null!;
}
