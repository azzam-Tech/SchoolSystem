using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.DAC.Entites;

public partial class ClassChatImage
{
    [Key]
    public int ClassChatImageId { get; set; }

    public int ClassChatId { get; set; }

    public string ClassChatImagePath { get; set; } = null!;

    [ForeignKey("ClassChatId")]
    [InverseProperty("ClassChatImages")]
    public virtual ClassChat ClassChat { get; set; } = null!;
}
