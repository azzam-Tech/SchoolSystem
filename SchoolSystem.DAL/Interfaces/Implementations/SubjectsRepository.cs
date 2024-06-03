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
    public class SubjectsRepository : BaseRepository<Subject>, ISubjectsRepository
    {
        public SubjectsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Subject> GetSubjectBylevelId(int levelId)
        {
            return await _context.Subjects.FirstOrDefaultAsync(l => l.LevelId == levelId);
        }
    }
}
