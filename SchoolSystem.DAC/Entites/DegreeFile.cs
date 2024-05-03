using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class DegreeFile
{
    [Key]
    public int DegreeFileId { get; set; }

    public int TermId { get; set; }

    public int DegreeTypeId { get; set; }

    public int StudentId { get; set; }

    [StringLength(100)]
    public string DegreeFileName { get; set; } = null!;

    public string DegreeFilePath { get; set; } = null!;

    [ForeignKey("DegreeTypeId")]
    [InverseProperty("DegreeFiles")]
    public virtual DegreeType DegreeType { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("DegreeFiles")]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey("TermId")]
    [InverseProperty("DegreeFiles")]
    public virtual Term Term { get; set; } = null!;
}
