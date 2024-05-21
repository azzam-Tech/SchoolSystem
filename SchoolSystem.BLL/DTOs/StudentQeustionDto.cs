using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class StudentQeustionDto
    {
        public int SubjectClassId { get; set; }

        public int StudentId { get; set; }

        public int TermId { get; set; }

        public string? StudentQeustionText { get; set; }

        public string? StudentQeustionImage { get; set; }

        public DateTime? StudentQeustionDate { get; set; }
    }
}
