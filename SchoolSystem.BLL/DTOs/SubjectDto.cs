using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class SubjectDto
    {
        public int LevelId { get; set; }

        [StringLength(50)]
        public string SubjectName { get; set; } = null!;

        public string? SubjectBook1 { get; set; }

        public string? SubjectBook2 { get; set; }

        public string? SubjectBook3 { get; set; }

        public string? SubjectImage { get; set; }
    }
}
