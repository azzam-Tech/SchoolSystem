using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Level
{
    [Key]
    public int LevelId { get; set; }

    public int DepartmentId { get; set; }

    [StringLength(50)]
    public string LevelName { get; set; } = null!;

    [InverseProperty("Level")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Levels")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("Level")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
