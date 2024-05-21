namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetStudentAttendanceDto
    {
        public int StudentAttendanceId { get; set; }

        public int StudentId { get; set; }

        public int TermId { get; set; }

        public bool StudentAttendanceValue { get; set; }

        public DateTime StudentAttendanceDate { get; set; }

    }


}
