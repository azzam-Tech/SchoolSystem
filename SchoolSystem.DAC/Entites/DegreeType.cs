using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class DegreeType
{
    [Key]
    public int DegreeTypeId { get; set; }

    [StringLength(50)]
    public string DegreeTypeName { get; set; } = null!;

    [InverseProperty("DegreeType")]
    public virtual ICollection<DegreeFile> DegreeFiles { get; set; } = new List<DegreeFile>();

    [InverseProperty("DegreeType")]
    public virtual ICollection<StudentDegree> StudentDegrees { get; set; } = new List<StudentDegree>();
}
