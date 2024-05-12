using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class SubjectClassDto
    {
        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public int SubjectTeacher { get; set; }
        [StringLength(50)]
        public string SubjectClassName { get; set; } = null!;
    }
}
