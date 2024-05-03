using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class ClassChat
{
    [Key]
    public int ClassChatId { get; set; }

    public int Classid { get; set; }

    public int? StudentId { get; set; }

    public string ClassChatText { get; set; } = null!;

    public string? ClassChatFilePath { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ClassChatDate { get; set; }

    [ForeignKey("Classid")]
    [InverseProperty("ClassChats")]
    public virtual Class Class { get; set; } = null!;

    [InverseProperty("ClassChat")]
    public virtual ICollection<ClassChatImage> ClassChatImages { get; set; } = new List<ClassChatImage>();

    [ForeignKey("StudentId")]
    [InverseProperty("ClassChats")]
    public virtual Student? Student { get; set; }
}
