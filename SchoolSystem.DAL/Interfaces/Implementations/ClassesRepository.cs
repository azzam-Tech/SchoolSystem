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
    public class ClassesRepository : BaseRepository<Class> , IClassesRepository
    {
        public ClassesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Class?> GetBYSupervisorIdAsync(int ClassSopervisorId)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.ClassSopervisor == ClassSopervisorId);
        }

        public async Task<IEnumerable<Class>> GetClassesBylevelId(int levelId)
        {
            return await _context.Classes.Where(c => c.LevelId == levelId).ToListAsync();
        }
    }

}
