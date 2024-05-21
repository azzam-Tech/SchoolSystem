using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetClassDto
    {
        public int LevelId { get; set; }

        public int ClassSopervisor { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; } = null!;
    }


}
