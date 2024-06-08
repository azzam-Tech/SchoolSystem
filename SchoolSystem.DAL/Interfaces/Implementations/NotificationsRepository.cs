using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class NotificationsRepository : BaseRepository<Notification>, INotificationsRepository
    {
        public NotificationsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationAsync()
        {
            return await _context.Notifications.Include(s => s.SubervisorNotifications).Include(t => t.TeacherNotifications).Include(r => r.NotificationRoles).ToListAsync();
        }
    }









}
