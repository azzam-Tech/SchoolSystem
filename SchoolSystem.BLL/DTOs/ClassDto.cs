using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class ClassDto
    {
        public int LevelId { get; set; }

        public int ClassSopervisor { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; } = null!;
    }
}
