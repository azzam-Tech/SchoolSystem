
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IFollowUpNoteBookRepository : IBaseRepository<FollowUpNoteBook>
    {
        Task<IEnumerable<FollowUpNoteBook>> GetByClassSubjectId(int id);
        Task<IEnumerable<FollowUpNoteBook>> GetByDateClassAsync(int id , DateOnly datetime);
    }
}
