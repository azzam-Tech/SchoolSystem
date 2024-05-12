using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class LevelDto
    {
        [Required]
        [StringLength(50)]
        public string LevelName { get; set; } = null!;
        public int DepartmentId { get; set; }
    }
}
