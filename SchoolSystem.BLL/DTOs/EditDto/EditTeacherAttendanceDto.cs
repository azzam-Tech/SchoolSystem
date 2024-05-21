namespace SchoolSystem.BLL.DTOs.EditDto
{
    public class EditTeacherAttendanceDto
    {

        public int TeacherAttendanceId { get; set; }

        public int UserId { get; set; }

        public bool TeacherAttendanceValue { get; set; }

        public DateTime TeacherAttendanceDate { get; set; }


    }
}
