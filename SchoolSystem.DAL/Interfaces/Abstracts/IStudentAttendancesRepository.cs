using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IStudentAttendancesRepository : IBaseRepository<StudentAttendance>
    {
        Task<IEnumerable<StudentAttendance>> GetAllBySoneIdAsync(int soneid);
    }


}
