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
    public class StudentsRepository : BaseRepository<Student>, IStudenstRepository
    {
        public StudentsRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Student?> GetByUserId(int userId)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<Student>> GetStudentByClassId(int id)
        {
            return await _context.Students.Include(u => u.User).Where(c => c.ClassId == id).ToListAsync();    
        }

        public async Task<IEnumerable<Student>> GetStudentByParentId(int id)
        {
            return await _context.Students.Include(u => u.User).Where(c => c.StedentParent == id).ToListAsync(); 
        }
    }
}
