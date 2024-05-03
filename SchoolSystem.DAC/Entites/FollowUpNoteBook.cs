using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class FollowUpNoteBook
{
    [Key]
    public int FollowUpNoteBookId { get; set; }

    public int SubjectClassId { get; set; }

    public int ClassId { get; set; }

    public int TermId { get; set; }

    public string FollowUpNoteBookText { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FollowUpNoteBookDate { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("FollowUpNoteBooks")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("SubjectClassId")]
    [InverseProperty("FollowUpNoteBooks")]
    public virtual SubjectClass SubjectClass { get; set; } = null!;

    [ForeignKey("TermId")]
    [InverseProperty("FollowUpNoteBooks")]
    public virtual Term Term { get; set; } = null!;
}
