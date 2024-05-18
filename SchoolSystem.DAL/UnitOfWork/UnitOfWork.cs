using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Implementations;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected AppDbContext _context;

        public IBaseRepository<User> Users { get; private set; }

        public IRolesRepository Roles { get; private set;}
        public IStudenstRepository Students { get; private set;}
        public ILevelsRepository Levels { get; private set;}
        public ISubjectsRepository Subjects { get; private set;}
        public ISubjectClassesRepository SubjectClasses { get; private set;}
        public IClassesRepository Classes { get; private set;}
        public IHomeWorksRepositroy HomeWorks { get; private set;}
        public IStudentQeustionsRepositroy StudentQeustions { get; private set;}
        public IReinforcementlessonsRepository Reinforcementlessons { get; private set;}
        public ISolutionsRepositroy Solutions { get; private set;}
        public IStudentDegreesRepositroy StudentDegrees { get; private set;}





        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(_context);
            Roles = new RolesRepository(_context);
            Students = new StudentsRepository (_context);
            Levels = new LevelsRepository(_context);
            Subjects = new SubjectsRepository(_context);
            SubjectClasses = new SubjectClassesRepository(_context);
            Classes = new ClassesRepository(_context);
            HomeWorks = new HomeWorksRepositroy(_context);
            StudentQeustions = new StudentQeustionsRepositroy(_context);
            Reinforcementlessons = new ReinforcementlessonsRepository(_context);
            Solutions = new SolutionsRepositroy(_context);
            StudentDegrees = new StudentDegreesRepositroy(_context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
