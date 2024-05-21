using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostLevelDto
    {
        [Required]
        [StringLength(50)]
        public string LevelName { get; set; } = null!;
        public int DepartmentId { get; set; }
    }

}
