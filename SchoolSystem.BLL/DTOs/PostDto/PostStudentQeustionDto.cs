namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostStudentQeustionDto
    {
        public int SubjectClassId { get; set; }

        public int StudentId { get; set; }

        public int TermId { get; set; }

        public string? StudentQeustionText { get; set; }

        //public string? StudentQeustionImage { get; set; }

        public DateTime? StudentQeustionDate { get; set; }
    }

}
