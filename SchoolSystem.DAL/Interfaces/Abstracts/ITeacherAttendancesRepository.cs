using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ITeacherAttendancesRepository : IBaseRepository<TeacherAttendance>
    {
        Task<IEnumerable<TeacherAttendance>> GetAllByTeacherIdAsync( int teacherId);
    }


}
