namespace SchoolSystem.BLL.DTOs.EditDto
{
    public class EditUserDto
    {

        public string UserName { get; set; } = null!;

        public string? Usernumber { get; set; }

        public string? UserImage { get; set; }

        public bool IsSupervisor { get; set; }
    }
}
