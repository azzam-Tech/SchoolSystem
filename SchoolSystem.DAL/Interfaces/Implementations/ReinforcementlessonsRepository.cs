using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class ReinforcementlessonsRepository : BaseRepository<Reinforcementlesson>, IReinforcementlessonsRepository
    {
        public ReinforcementlessonsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reinforcementlesson>> GetBySubjectClassId(int id)
        {
            return await _context.Reinforcementlessons.Where(h => h.SubjectClassId == id).ToListAsync();
        }
    }
}
