using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Reinforcementlesson
{
    [Key]
    public int ReinforcementlessonId { get; set; }

    public int SubjectClassId { get; set; }

    public int TermId { get; set; }

    [StringLength(100)]
    public string ReinforcementlessonTitle { get; set; } = null!;

    public string? Reinforcementlessondescription { get; set; }

    public string? ReinforcementlessonFile { get; set; }

    public string? Reinforcementlessonlink { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReinforcementlessonDate { get; set; }

    [ForeignKey("SubjectClassId")]
    [InverseProperty("Reinforcementlessons")]
    public virtual SubjectClass SubjectClass { get; set; } = null!;

    [ForeignKey("TermId")]
    [InverseProperty("Reinforcementlessons")]
    public virtual Term Term { get; set; } = null!;
}
