using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class ParentSubervaisorChat
{
    [Key]
    public int ParentSubervaisorChatId { get; set; }

    public int Sender { get; set; }

    public int Recever { get; set; }

    public string ParentSubervaisorChatText { get; set; } = null!;

    public string? ParentSubervaisorChatImagePath { get; set; }

    public string? ParentSubervaisorChatFilePath { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ParentSubervaisorChatDate { get; set; }

    [ForeignKey("Recever")]
    [InverseProperty("ParentSubervaisorChatReceverNavigations")]
    public virtual User ReceverNavigation { get; set; } = null!;

    [ForeignKey("Sender")]
    [InverseProperty("ParentSubervaisorChatSenderNavigations")]
    public virtual User SenderNavigation { get; set; } = null!;
}
