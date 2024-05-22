using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetByRoleId(int RoleId);
    }
}
