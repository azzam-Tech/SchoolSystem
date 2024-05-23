using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class SolutionsRepositroy : BaseRepository<Solution>, ISolutionsRepositroy
    {
        public SolutionsRepositroy(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Solution>> GetByHomeworkIdAsync(int id)
        {
            return await _context.Solutions.Where(s => s.HomeWorkId == id).ToListAsync();
        }

        public async Task<Solution> GetByStudentId(int studentId, int homeworkId)
        {
            return await _context.Solutions.FirstOrDefaultAsync(s => s.HomeWorkId == homeworkId && s.StudentId == studentId);

        }
    }

}
