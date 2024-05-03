using System;
using System.Collections.Generic;

namespace SchoolSystem.DAL.Entites;

public partial class ParentSubervaisorChat
{
    public int ParentSubervaisorChatId { get; set; }

    public int Sender { get; set; }

    public int Recever { get; set; }

    public string ParentSubervaisorChatText { get; set; } = null!;

    public string? ParentSubervaisorChatImagePath { get; set; }

    public string? ParentSubervaisorChatFilePath { get; set; }

    public DateTime? ParentSubervaisorChatDate { get; set; }

    public virtual User ReceverNavigation { get; set; } = null!;

    public virtual User SenderNavigation { get; set; } = null!;
}
