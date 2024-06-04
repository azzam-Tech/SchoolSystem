namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostStudentAttendanceDto
    {


        public int StudentId { get; set; }

        public int TermId { get; set; }

        public bool StudentAttendanceValue { get; set; }

        public DateTime StudentAttendanceDate { get; set; }

    }
}
