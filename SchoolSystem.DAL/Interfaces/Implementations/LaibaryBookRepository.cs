using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class LaibaryBookRepository : BaseRepository<LaibaryBook>, ILaibaryBookRepository
    {
        public LaibaryBookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LaibaryBook>> GetBySectionId(int id)
        {
            return await _context.LaibaryBooks.Where(i => i.Sectionid == id).ToListAsync();    
        }
    }
}
