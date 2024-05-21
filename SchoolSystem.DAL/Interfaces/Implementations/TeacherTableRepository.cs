using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class TeacherTableRepository : BaseRepository<TeacherTable>, ITeacherTableRepository
    {
        public TeacherTableRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TeacherTable>> GetByTeacherIdAsync(int Teacherid)
        {
            return await _context.TeacherTables
              .Where(x => x.UserId == Teacherid)
              .ToListAsync();
            throw new NotImplementedException();
        }
    }
}