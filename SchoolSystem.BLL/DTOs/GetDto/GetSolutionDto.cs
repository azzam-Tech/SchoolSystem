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

        //public string? SolutionImage { get; set; }
        public string? StudentName { get; set; }

        public string? SolutionFile { get; set; }

        public DateTime? SolutionDate { get; set; }

        public decimal? SolutionDegree { get; set; }

        public string? Solutionnote { get; set; }
    }
}
