using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class StudentAttendancesRepository : BaseRepository<StudentAttendance>, IStudentAttendancesRepository
    {
        public StudentAttendancesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StudentAttendance>> GetAllBySoneIdAsync(int soneid)
        {
            //return await _context.StudentAttendances.Include(s => s.Student).ThenInclude(u => u.User).Where(ss => ss.StudentId== soneid && ss.StudentAttendanceValue == false).ToListAsync();    
            return await _context.StudentAttendances.Where(ss => ss.StudentId== soneid && ss.StudentAttendanceValue == false).ToListAsync();    
        }
    }
}