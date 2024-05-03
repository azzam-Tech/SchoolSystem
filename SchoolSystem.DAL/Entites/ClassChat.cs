using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class ClassChat
{
    public int ClassChatId { get; set; }

    public int Classid { get; set; }

    public int? StudentId { get; set; }

    public string ClassChatText { get; set; } = null!;

    public string? ClassChatFilePath { get; set; }

    public DateTime ClassChatDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<ClassChatImage> ClassChatImages { get; set; } = new List<ClassChatImage>();

    public virtual Student? Student { get; set; }
}
