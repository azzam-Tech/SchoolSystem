using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class ClassChatImage
{
    public int ClassChatImageId { get; set; }

    public int ClassChatId { get; set; }

    public string ClassChatImagePath { get; set; } = null!;

    public virtual ClassChat ClassChat { get; set; } = null!;
}
