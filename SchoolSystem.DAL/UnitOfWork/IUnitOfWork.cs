using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using SchoolSystem.DAL.Interfaces.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> Users { get; } 
        IRolesRepository Roles { get; }
        IStudenstRepository Students { get; }
        ILevelsRepository Levels { get; }
        ISubjectsRepository Subjects { get; }
        ISubjectClassesRepository SubjectClasses { get; }
        IClassesRepository Classes { get; }
        IHomeWorksRepositroy HomeWorks { get; }
        IStudentQeustionsRepositroy StudentQeustions { get; }
        IReinforcementlessonsRepository Reinforcementlessons { get; }
        ISolutionsRepositroy Solutions { get; }
        IStudentDegreesRepositroy StudentDegrees { get; }
        IClassTimeTablesRepository ClassTimeTables { get; }
        IFollowUpNoteBookRepository FollowUpNoteBooks { get; }





        void Complete();
        void Commit();
        Task CommitAsync();
        void Save();
        Task SaveAsync();
    }
}
