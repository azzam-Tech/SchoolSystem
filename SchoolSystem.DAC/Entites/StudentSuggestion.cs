using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class StudentSuggestion
{
    [Key]
    public int StudentSuggestionId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public string? StudentSuggestionText { get; set; }

    public string? StudentSuggestionImage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StudentSuggestionDate { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("StudentSuggestions")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentSuggestions")]
    public virtual Student Student { get; set; } = null!;
}
