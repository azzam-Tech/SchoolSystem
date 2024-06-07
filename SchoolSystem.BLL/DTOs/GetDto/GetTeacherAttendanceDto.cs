namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetTeacherAttendanceDto
    {

        public int TeacherAttendanceId { get; set; }

        public int UserId { get; set; }

        public bool TeacherAttendanceValue { get; set; }

        public DateOnly TeacherAttendanceDate { get; set; }


    }




}
