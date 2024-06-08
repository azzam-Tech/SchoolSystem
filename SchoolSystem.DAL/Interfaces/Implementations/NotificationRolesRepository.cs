using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class NotificationRolesRepository : BaseRepository<NotificationRole>, INotificationRolesRepository
    {
        public NotificationRolesRepository(AppDbContext context) : base(context)
        {
        }
    }









}
