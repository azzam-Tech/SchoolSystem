using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.EditDto;
using SchoolSystem.Api.FileServices;
using SchoolSystem.BLL.DTOs;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IManageFiles manageFiles;
        public NotificationsController(IUnitOfWork unitOfWork, IMapper mapper, IManageFiles manageFiles)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.manageFiles = manageFiles;
        }

        // create create a post notification method that using PostNotificationDto as parameter this function save notification info in four tables (Notifications , NotificationRole ,TeacherNotification , SubervisorNotification)
        [HttpPost("PostNotification")]
        public async Task<IActionResult> PostNotification([FromForm] PostNotificationDto postNotificationDto)
        {
            try
            {
                Notification notification = new Notification
                {
                    UserId = postNotificationDto.UserId,
                    NotificationTitle = postNotificationDto.NotificationTitle,
                    NotificationText = postNotificationDto.NotificationText,
                    NotificationDate = DateTime.Now
                };

                var shema = $"{Request.Scheme}://";
                var host = $"{Request.Host}/";

                var imagePath1 = shema + host + await manageFiles.SaveImage(postNotificationDto.NotificationImagePath, "Notification");

                var imagePath = imagePath1.Replace("/wwwroot", "");

                notification.NotificationImagePath = imagePath;

                await _unitOfWork.Notifications.AddAsync(notification);
                await _unitOfWork.SaveAsync();


                foreach (var roleId in postNotificationDto.RoleId)
                {
                    var notificationRole = new NotificationRole
                    {
                        NotificationId = notification.NotificationId,
                        RoleId = roleId
                    };
                    await _unitOfWork.NotificationRoles.AddAsync(notificationRole);
                    await _unitOfWork.SaveAsync();
                }

                if (postNotificationDto.ClassId != 0)
                {
                    var subervisorNotification = new SubervisorNotification
                    {
                        NotificationId = notification.NotificationId,
                        ClassId = postNotificationDto.ClassId
                    };
                    await _unitOfWork.SubervisorNotifications.AddAsync(subervisorNotification);
                    await _unitOfWork.SaveAsync();
                }

                if (postNotificationDto.SubjectClassId != 0)
                {
                    var teacherNotification = new TeacherNotification
                    {
                        NotificationId = notification.NotificationId,
                        SubjectClassId = postNotificationDto.SubjectClassId
                    };
                    await _unitOfWork.TeacherNotifications.AddAsync(teacherNotification);
                    await _unitOfWork.SaveAsync();
                }

                ApiResponse4 response = new ApiResponse4(message: "Notification has been added successfully");
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        // create a method to get notification info from all notification tables (Notifications , NotificationRole ,TeacherNotification , SubervisorNotification) using GetNotificationDto without using _mapper
        [HttpGet("GetNotification")]
        public async Task<IActionResult> GetNotification()
        {
            try
            {
                var notifications = await _unitOfWork.Notifications.GetAllNotificationAsync();
                var notificationDto = notifications.Select(n => new GetNotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    NotificationTitle = n.NotificationTitle,
                    NotificationText = n.NotificationText,
                    NotificationImagePath = n.NotificationImagePath,
                    NotificationDate = n.NotificationDate,
                    Roles = n.NotificationRoles.Select(nr => nr.RoleId).ToList(),
                    ClassId = n.SubervisorNotifications.Select(sn => sn.ClassId).FirstOrDefault(),
                    SubjectClassId = n.TeacherNotifications.Select(tn => tn.SubjectClassId).FirstOrDefault()
                });



                ApiResponse6<IEnumerable<GetNotificationDto>> response = new(notificationDto);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        [HttpGet("GetNotificationByClassId/{id}")]
        public async Task<IActionResult> GetNotificationByClassId(int id)
        {
            try
            {
                var notifications = await _unitOfWork.Notifications.GetAllNotificationAsync();
                var notificationDto = notifications.Select(n => new GetNotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    NotificationTitle = n.NotificationTitle,
                    NotificationText = n.NotificationText,
                    NotificationImagePath = n.NotificationImagePath,
                    NotificationDate = n.NotificationDate,
                    Roles = n.NotificationRoles.Select(nr => nr.RoleId).ToList(),
                    ClassId = n.SubervisorNotifications.Select(sn => sn.ClassId).FirstOrDefault(),
                    SubjectClassId = n.TeacherNotifications.Select(tn => tn.SubjectClassId).FirstOrDefault()
                });

                var classnotis = new List<GetClassNotificationDto>();
                foreach (var noti in notificationDto)
                {
                    if (noti.ClassId == id)
                    {
                        var classnoti = new GetClassNotificationDto
                        {
                            NotificationId = noti.NotificationId,
                            NotificationTitle = noti.NotificationTitle,
                            NotificationText = noti.NotificationText,
                            NotificationDate = noti.NotificationDate,
                            NotificationImagePath = noti.NotificationImagePath,
                        };
                        classnotis.Add(classnoti);
                    }
                }

                ApiResponse6<IEnumerable<GetClassNotificationDto>> response = new(classnotis);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        [HttpGet("GetNotificationBySubjectClassId/{id}")]
        public async Task<IActionResult> GetNotificationBySubjectClassId(int id)
        {
            try
            {
                var notifications = await _unitOfWork.Notifications.GetAllNotificationAsync();
                var notificationDto = notifications.Select(n => new GetNotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    NotificationTitle = n.NotificationTitle,
                    NotificationText = n.NotificationText,
                    NotificationImagePath = n.NotificationImagePath,
                    NotificationDate = n.NotificationDate,
                    Roles = n.NotificationRoles.Select(nr => nr.RoleId).ToList(),
                    ClassId = n.SubervisorNotifications.Select(sn => sn.ClassId).FirstOrDefault(),
                    SubjectClassId = n.TeacherNotifications.Select(tn => tn.SubjectClassId).FirstOrDefault()
                });

                var classnotis = new List<GetClassNotificationDto>();
                foreach (var noti in notificationDto)
                {
                    if (noti.SubjectClassId == id)
                    {
                        var classnoti = new GetClassNotificationDto
                        {
                            NotificationId = noti.NotificationId,
                            NotificationTitle = noti.NotificationTitle,
                            NotificationText = noti.NotificationText,
                            NotificationDate = noti.NotificationDate,
                            NotificationImagePath = noti.NotificationImagePath,
                        };
                        classnotis.Add(classnoti);
                    }
                }





                ApiResponse6<IEnumerable<GetClassNotificationDto>> response = new(classnotis);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }



        [HttpGet("GetNotificationForAll/{id}")]
        public async Task<IActionResult> GetNotificationForAll()
        {
            try
            {
                var notifications = await _unitOfWork.Notifications.GetAllNotificationAsync();
                var notificationDto = notifications.Select(n => new GetNotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    NotificationTitle = n.NotificationTitle,
                    NotificationText = n.NotificationText,
                    NotificationImagePath = n.NotificationImagePath,
                    NotificationDate = n.NotificationDate,
                    Roles = n.NotificationRoles.Select(nr => nr.RoleId).ToList(),
                    ClassId = n.SubervisorNotifications.Select(sn => sn.ClassId).FirstOrDefault(),
                    SubjectClassId = n.TeacherNotifications.Select(tn => tn.SubjectClassId).FirstOrDefault()
                });

                var classnotis = new List<GetClassNotificationDto>();
                foreach (var noti in notificationDto)
                {
                    if (noti.SubjectClassId == 0 && noti.ClassId == 0 )
                    {
                        var classnoti = new GetClassNotificationDto
                        {
                            NotificationId = noti.NotificationId,
                            NotificationTitle = noti.NotificationTitle,
                            NotificationText = noti.NotificationText,
                            NotificationDate = noti.NotificationDate,
                            NotificationImagePath = noti.NotificationImagePath,
                        };
                        classnotis.Add(classnoti);
                    }
                }





                ApiResponse6<IEnumerable<GetClassNotificationDto>> response = new(classnotis);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        [HttpGet("GetNotificationForTeacher")]
        public async Task<IActionResult> GetNotificationForTeacher()
        {
            try
            {
                var notifications = await _unitOfWork.Notifications.GetAllNotificationAsync();
                var notificationDto = notifications.Select(n => new GetNotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    NotificationTitle = n.NotificationTitle,
                    NotificationText = n.NotificationText,
                    NotificationImagePath = n.NotificationImagePath,
                    NotificationDate = n.NotificationDate,
                    Roles = n.NotificationRoles.Select(nr => nr.RoleId).ToList(),
                    ClassId = n.SubervisorNotifications.Select(sn => sn.ClassId).FirstOrDefault(),
                    SubjectClassId = n.TeacherNotifications.Select(tn => tn.SubjectClassId).FirstOrDefault()
                });

                var classnotis = new List<GetClassNotificationDto>();
                foreach (var noti in notificationDto)
                {
                    if (noti.SubjectClassId == 0 && noti.ClassId == 0 && noti.Roles!.Contains(4) && noti.Roles.Contains(5) == false && noti.Roles.Contains(6) == false)
                    {
                        var classnoti = new GetClassNotificationDto
                        {
                            NotificationId = noti.NotificationId,
                            NotificationTitle = noti.NotificationTitle,
                            NotificationText = noti.NotificationText,
                            NotificationDate = noti.NotificationDate,
                            NotificationImagePath = noti.NotificationImagePath,
                        };
                        classnotis.Add(classnoti);
                    }
                }


                ApiResponse6<IEnumerable<GetClassNotificationDto>> response = new(classnotis);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }


        [HttpGet("GetNotificationForForParent")]
        public async Task<IActionResult> GetNotificationForForParent()
        {
            try
            {
                var notifications = await _unitOfWork.Notifications.GetAllNotificationAsync();
                var notificationDto = notifications.Select(n => new GetNotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    NotificationTitle = n.NotificationTitle,
                    NotificationText = n.NotificationText,
                    NotificationImagePath = n.NotificationImagePath,
                    NotificationDate = n.NotificationDate,
                    Roles = n.NotificationRoles.Select(nr => nr.RoleId).ToList(),
                    ClassId = n.SubervisorNotifications.Select(sn => sn.ClassId).FirstOrDefault(),
                    SubjectClassId = n.TeacherNotifications.Select(tn => tn.SubjectClassId).FirstOrDefault()
                });

                var classnotis = new List<GetClassNotificationDto>();
                foreach (var noti in notificationDto)
                {
                    if (noti.SubjectClassId == 0 && noti.ClassId == 0 && noti.Roles!.Contains(6) && noti.Roles.Contains(5) == false && noti.Roles.Contains(4) == false)
                    {
                        var classnoti = new GetClassNotificationDto
                        {
                            NotificationId = noti.NotificationId,
                            NotificationTitle = noti.NotificationTitle,
                            NotificationText = noti.NotificationText,
                            NotificationDate = noti.NotificationDate,
                            NotificationImagePath = noti.NotificationImagePath,
                        };
                        classnotis.Add(classnoti);
                    }
                }


                ApiResponse6<IEnumerable<GetClassNotificationDto>> response = new(classnotis);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }









    }
}
