using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class TeacherAttendancesRepository : BaseRepository<TeacherAttendance>, ITeacherAttendancesRepository
    {
        public TeacherAttendancesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TeacherAttendance>> GetAllByTeacherIdAsync( int teachrId)
        {
            return await _context.TeacherAttendances.Where(t => t.UserId == teachrId && t.TeacherAttendanceValue == false ).ToListAsync(); 

        }
    }
}