using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IReinforcementlessonsRepository : IBaseRepository<Reinforcementlesson>
    {
        Task<IEnumerable<Reinforcementlesson>> GetBySubjectClassId(int id);
    } 
}
