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
    }
}