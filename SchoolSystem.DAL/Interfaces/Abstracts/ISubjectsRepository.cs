using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ISubjectsRepository : IBaseRepository<Subject>
    {

        Task<Subject> GetSubjectBylevelId(int levelId);
        Task<Subject> GetSubjectBySubjectId(int subjectId);
    }
}
