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
    public class HomeWorksRepositroy : BaseRepository<HomeWork> , IHomeWorksRepositroy
    {
        public HomeWorksRepositroy(AppDbContext context) : base(context)
        {
        }
    }
}
