using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ILevelsRepository : IBaseRepository<Level>
    {
        Task<IEnumerable<Level>> GetByDepartmentId(int id);
    }
}
