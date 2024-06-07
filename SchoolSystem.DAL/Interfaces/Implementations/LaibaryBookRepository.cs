﻿using SchoolSystem.DAL.Data;
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
    }
}