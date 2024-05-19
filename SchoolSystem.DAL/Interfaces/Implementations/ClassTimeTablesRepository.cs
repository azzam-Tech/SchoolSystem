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
    public class ClassTimeTablesRepository : BaseRepository<ClassTimeTable>, IClassTimeTablesRepository
    {
        public ClassTimeTablesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClassTimeTable>> GetClassTimeTablesByClassId(int classId)
        {
           return await _context.ClassTimeTables
                .Where(x => x.ClassId == classId)
                .ToListAsync();
        }
    }
}
