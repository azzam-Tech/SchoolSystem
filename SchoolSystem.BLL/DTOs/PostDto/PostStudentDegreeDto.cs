namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostStudentDegreeDto
    {
        public int SubjectClassId { get; set; }

        public int StudentId { get; set; }

        public int TermId { get; set; }

        public int DegreeTypeId { get; set; }

        public decimal? StudentDegreeValue { get; set; }

        public string? StudentDegreenote { get; set; }
    }

}
