using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IStudenstRepository : IBaseRepository<Student>
    {
        Task<Student?> GetByUserId(int userId);
        Task<IEnumerable< Student>> GetStudentByClassId(int id);
        Task<IEnumerable<Student>> GetStudentByParentId(int id);
    }
}
