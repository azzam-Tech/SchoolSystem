﻿using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface ISolutionsRepositroy : IBaseRepository<Solution>
    {
        Task <IEnumerable<Solution>> GetByHomeworkIdAsync(int id);
        Task<Solution> GetByStudentId(int studentId , int homeworkId );
    }
}
