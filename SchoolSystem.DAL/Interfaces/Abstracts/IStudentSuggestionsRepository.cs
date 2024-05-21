using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IStudentSuggestionsRepository : IBaseRepository<StudentSuggestion>
    {
        Task<IEnumerable< StudentSuggestion>> GetByClassIdAsync(int id);
    }


}
