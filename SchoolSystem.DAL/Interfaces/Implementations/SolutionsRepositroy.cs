﻿using SchoolSystem.DAL.Data;
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
    public class SolutionsRepositroy : BaseRepository<Solution>, ISolutionsRepositroy
    {
        public SolutionsRepositroy(AppDbContext context) : base(context)
        {

        }
    }

}
