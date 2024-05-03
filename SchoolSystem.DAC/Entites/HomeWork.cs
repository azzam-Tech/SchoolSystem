using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class HomeWork
{
    [Key]
    public int HomeWorkId { get; set; }

    public int SubjectClassId { get; set; }

    public int TermId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal HomeWorkDegree { get; set; }

    [StringLength(100)]
    public string HomeWorkTitle { get; set; } = null!;

    public string? HomeWorkdescription { get; set; }

    public string? HomeWorkText { get; set; }

    public string? HomeWorkImagePath { get; set; }

    [StringLength(100)]
    public string? HomeWorkDeadline { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? HomeWorkDate { get; set; }

    [InverseProperty("HomeWork")]
    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    [ForeignKey("SubjectClassId")]
    [InverseProperty("HomeWorks")]
    public virtual SubjectClass SubjectClass { get; set; } = null!;

    [ForeignKey("TermId")]
    [InverseProperty("HomeWorks")]
    public virtual Term Term { get; set; } = null!;
}
