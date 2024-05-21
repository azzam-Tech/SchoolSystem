namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetStudentQeustionDto
    {
        public int SubjectClassId { get; set; }

        public int StudentId { get; set; }

        public int TermId { get; set; }

        public string? StudentQeustionText { get; set; }

        public string? StudentQeustionImage { get; set; }

        public DateTime? StudentQeustionDate { get; set; }
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
