using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostUserDto
    {


        public int RoleId { get; set; }

        public string UserName { get; set; } = null!;

        public string? Usernumber { get; set; }


        public string? UserImage { get; set; }

        public bool IsSupervisor { get; set; }
    }
}
