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
    public class SubjectClassesRepository :BaseRepository<SubjectClass> , ISubjectClassesRepository
    {
        public SubjectClassesRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<SubjectClass>> GetByClassId(int id)
        {
            return await _context.SubjectClasses.Where(i => i.ClassId == id).ToListAsync();
        }

        public async Task<IEnumerable<SubjectClass>> GetByTeacherId(int id)
        {
            return await _context.SubjectClasses.Where(i => i.SubjectTeacher == id).ToListAsync();
        }
    }
}
