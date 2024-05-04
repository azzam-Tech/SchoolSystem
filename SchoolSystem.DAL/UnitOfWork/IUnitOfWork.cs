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
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> Users { get; } 
        IRolesRepository Roles { get; }



        void Commit();
        Task CommitAsync();
        void Save();
        Task SaveAsync();
    }
}
