using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.EditDto
{
    public class EditLevelDto
    {
        [Required]
        [StringLength(50)]
        public string LevelName { get; set; } = null!;
    }
}
