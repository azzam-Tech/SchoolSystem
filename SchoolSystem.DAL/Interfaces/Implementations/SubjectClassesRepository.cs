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

        public async Task<SubjectClass> findincludeone(SubjectClass subjectClass)
        {
            var x =await _context.Set<SubjectClass>().Include(i => i.Class).Include(i => i.Subject).ThenInclude(i=> i.Level).SingleOrDefaultAsync();

            return x;
        }
    }
}
