using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class StudentSuggestionsRepository : BaseRepository<StudentSuggestion>, IStudentSuggestionsRepository
    {
        public StudentSuggestionsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StudentSuggestion>> GetByClassIdAsync(int id)
        {
            return await _context.StudentSuggestions.Include(s => s.Student).ThenInclude( u => u.User).Where( c => c.ClassId == id).ToListAsync();
        }
    }
}