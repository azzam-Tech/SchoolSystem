using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostClassDto
    {
        public int LevelId { get; set; }

        public int ClassSopervisor { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; } = null!;
    }

    public class PostNotificationDto
    {

      //  public int NotificationId { get; set; }

        public int UserId { get; set; }

        public string NotificationTitle { get; set; } = null!;

        public string? NotificationText { get; set; }

        public IFormFile? NotificationImagePath { get; set; }

       // public DateTime? NotificationDate { get; set; }

       // public int NotificationRoleId { get; set; }

        public List<int>? RoleId { get; set; }

       // public int SubervisorNotificationId { get; set; }

        public int ClassId { get; set; }

       // public int TeacherNotificationId { get; set; }

        public int SubjectClassId { get; set; }


    }


    public class GetNotificationDto
    {

         public int NotificationId { get; set; }

        public int UserId { get; set; }

        public string NotificationTitle { get; set; } = null!;

        public string? NotificationText { get; set; }

        public string? NotificationImagePath { get; set; }

        public DateTime? NotificationDate { get; set; }

        // public int NotificationRoleId { get; set; }

        public List<int>? Roles { get; set; }

        // public int SubervisorNotificationId { get; set; }

        public int ClassId { get; set; }

        // public int TeacherNotificationId { get; set; }

        public int SubjectClassId { get; set; }


    }

}
