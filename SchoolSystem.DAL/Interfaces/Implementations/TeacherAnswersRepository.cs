using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class TeacherAnswersRepository : BaseRepository<TeacherAnswer>, ITeacherAnswersRepository
    {
        public TeacherAnswersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<TeacherAnswer> GetByTeacherIdAsync(int questionid)
        {
            return await _context.TeacherAnswers.Where(q => q.StudentQeustionId == questionid).FirstOrDefaultAsync();
        }
    }
}