using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetSubjectClassDto
    {
        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public int SubjectTeacher { get; set; }
        [StringLength(50)]
        public string SubjectClassName { get; set; } = null!;
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
