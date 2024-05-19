using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetLevelDto
    {
        [Required]
        [StringLength(50)]
        public string LevelName { get; set; } = null!;
        public int DepartmentId { get; set; }
    }


}
