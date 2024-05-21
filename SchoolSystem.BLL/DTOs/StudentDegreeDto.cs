using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class StudentDegreeDto
    {
        public int StudentDegreeId { get; set; }

        public int SubjectClassId { get; set; }

        public int StudentId { get; set; }

        public int TermId { get; set; }

        public int DegreeTypeId { get; set; }

        public decimal? StudentDegreeValue { get; set; }

        public string? StudentDegreenote { get; set; }
    }
}
