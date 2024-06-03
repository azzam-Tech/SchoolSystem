namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetStudentQeustionDto
    {
        public int StudentQeustionId { get; set; }

        //public int SubjectClassId { get; set; }

        //public int StudentId { get; set; }

        //public int TermId { get; set; }
        public string? StudentName { get; set; }

        public string? StudentQeustionText { get; set; }
        public string? TeacherAnswerText { get; set; }

        //public string? StudentQeustionImage { get; set; }

        public DateTime? StudentQeustionDate { get; set; }
    }





}
