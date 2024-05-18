using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetSolutionDto
    {
        public int SolutionId { get; set; }

        public int HomeWorkId { get; set; }

        public int StudentId { get; set; }

        public string? SolutionImage { get; set; }

        public string? SolutionFile { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SolutionDate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? SolutionDegree { get; set; }

        public string? Solutionnote { get; set; }
    }
}
