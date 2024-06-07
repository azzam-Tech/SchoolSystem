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
    public class FollowUpNoteBookRepository : BaseRepository<FollowUpNoteBook>, IFollowUpNoteBookRepository
    {
        public FollowUpNoteBookRepository(AppDbContext context) : base(context)
        {
           
        }

        public async Task<IEnumerable<FollowUpNoteBook>> GetByClassSubjectId(int id)
        {
            return await _context.FollowUpNoteBooks.Where(x => x.SubjectClassId == id ).ToListAsync();

        }

        public async Task<IEnumerable<FollowUpNoteBook>> GetByDateClassAsync(int id , DateOnly datetime)
        {
             return await _context.FollowUpNoteBooks.Include(s => s.SubjectClass).ThenInclude( ss => ss.Subject).Where(x => x.ClassId == id && x.FollowUpNoteBookDate == datetime).ToListAsync();
            
        }
    }
}
