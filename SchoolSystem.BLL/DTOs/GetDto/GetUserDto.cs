using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetUserDto
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
