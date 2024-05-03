using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class StudentSuggestion
{
    public int StudentSuggestionId { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public string? StudentSuggestionText { get; set; }

    public string? StudentSuggestionImage { get; set; }

    public DateTime? StudentSuggestionDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
