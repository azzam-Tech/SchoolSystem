using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ITeacherEvaluationsRepository : IBaseRepository<TeacherEvaluation>
    {
        Task<TeacherEvaluation> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<TeacherEvaluation>> GetAllwithnameAsync();
        //Task<IEnumerable<User>> CraeateAll();
        Task CraeateAll();
    }


}
