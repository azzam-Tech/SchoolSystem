using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostUserDto
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = null!;

        [StringLength(20)]
        public string? Usernumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Userpassword { get; set; } = null!;

        public string? UserImage { get; set; }

        public bool IsSupervisor { get; set; }
    }

}
