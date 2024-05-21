using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ITeacherAnswersRepository : IBaseRepository<TeacherAnswer>
    {
        Task<TeacherAnswer> GetByTeacherIdAsync(int questionid);
    }


}
