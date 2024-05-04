using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces;
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

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(_context);
            Roles = new RolesRepository(_context);
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

    }
}
