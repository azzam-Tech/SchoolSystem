using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetSubjectDto
    {
        public int LevelId { get; set; }

        [StringLength(50)]
        public string SubjectName { get; set; } = null!;

        public string? SubjectBook1 { get; set; }

        public string? SubjectBook2 { get; set; }

        public string? SubjectBook3 { get; set; }

        public string? SubjectImage { get; set; }
    }

    //public class StudentDegreeDto
    //{
    //    public int StudentDegreeId { get; set; }

    //    public int SubjectClassId { get; set; }

    //    public int StudentId { get; set; }

    //    public int TermId { get; set; }

    //    public int DegreeTypeId { get; set; }

    //    public decimal? StudentDegreeValue { get; set; }

    //    public string? StudentDegreenote { get; set; }
    //}




}
