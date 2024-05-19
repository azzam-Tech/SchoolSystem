using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostClassDto
    {
        public int LevelId { get; set; }

        public int ClassSopervisor { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; } = null!;
    }

}
