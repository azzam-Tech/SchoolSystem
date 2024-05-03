using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class Section
{
    [Key]
    public int SectionId { get; set; }

    [StringLength(50)]
    public string SectionName { get; set; } = null!;

    [InverseProperty("Section")]
    public virtual ICollection<LaibaryBook> LaibaryBooks { get; set; } = new List<LaibaryBook>();
}
