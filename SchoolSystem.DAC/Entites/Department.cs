using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [StringLength(50)]
    public string DepartmentName { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();
}
