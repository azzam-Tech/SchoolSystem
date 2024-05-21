using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostSubjectDto
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
