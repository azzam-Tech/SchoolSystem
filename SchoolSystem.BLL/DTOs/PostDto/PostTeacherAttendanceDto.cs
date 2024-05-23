namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostTeacherAttendanceDto
    {
        public int UserId { get; set; }

        public bool TeacherAttendanceValue { get; set; }

        public DateTime TeacherAttendanceDate { get; set; }


    }

    public class PostTeacherAttendanceDtoinfo
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }


    }
}
