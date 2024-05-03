using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    public int LevelId { get; set; }

    [StringLength(50)]
    public string SubjectName { get; set; } = null!;

    public string? SubjectBook1 { get; set; }

    public string? SubjectBook2 { get; set; }

    public string? SubjectBook3 { get; set; }

    public string? SubjectImage { get; set; }

    [ForeignKey("LevelId")]
    [InverseProperty("Subjects")]
    public virtual Level Level { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<SubjectClass> SubjectClasses { get; set; } = new List<SubjectClass>();
}
