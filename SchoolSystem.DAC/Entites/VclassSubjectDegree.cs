using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

[Keyless]
public partial class VclassSubjectDegree
{
    [StringLength(100)]
    public string StudentName { get; set; } = null!;

    [StringLength(50)]
    public string ClassName { get; set; } = null!;

    [StringLength(50)]
    public string SubjectClassName { get; set; } = null!;

    [Column(TypeName = "decimal(38, 2)")]
    public decimal? TotalMarks { get; set; }
}
