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
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; } = null!;

        public string? Usernumber { get; set; }

        public string Userpassword { get; set; } = null!;

        public string? UserImage { get; set; }

        public bool IsSupervisor { get; set; }
    }

}
