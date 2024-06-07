using Microsoft.AspNetCore.Http;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostHomeWorkDto
    {
        public int SubjectClassId { get; set; }

        public int TermId { get; set; }

        public decimal HomeWorkDegree { get; set; }

        public string HomeWorkTitle { get; set; } = null!;

        public string? HomeWorkdescription { get; set; }

        public string? HomeWorkText { get; set; }

        public IFormFile? HomeWorkImagePath { get; set; }

        public DateOnly? HomeWorkDeadline { get; set; }

        //public DateTime? HomeWorkDate { get; set; }
    }

}
