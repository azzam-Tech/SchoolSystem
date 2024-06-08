using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface INotificationsRepository : IBaseRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetAllNotificationAsync();
    }


}
