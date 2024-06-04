using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostSolutionDto
    {
        public int HomeWorkId { get; set; }

        public int StudentId { get; set; }

        //public string? SolutionImage { get; set; }

        public IFormFile? SolutionFile { get; set; }

        public DateTime? SolutionDate { get; set; }

        //public decimal? SolutionDegree { get; set; }

        //public string? Solutionnote { get; set; }
    }

}
