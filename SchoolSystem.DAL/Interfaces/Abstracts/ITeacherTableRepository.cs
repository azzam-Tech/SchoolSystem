using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ITeacherTableRepository : IBaseRepository<TeacherTable>
    {
        Task<IEnumerable<TeacherTable>> GetByTeacherIdAsync(int id);
    }


}
