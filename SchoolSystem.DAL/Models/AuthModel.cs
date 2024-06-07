using SchoolSystem.BLL.DTOs.GetDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Models
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsSuperVaisor { get; set; }
        public int ClassId { get; set; }
        public int LevelId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; } /*= DateTime.UtcNow;*/
        //public GetStudentLoginDto? StudentInfo { get; set; }   
        public int StudentId { get; set; }

        public int StedentParent { get; set; }

        public int StudentClassId { get; set; }
    }
}
