using Microsoft.EntityFrameworkCore;
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
    public class StudentQeustionsRepositroy : BaseRepository<StudentQeustion> , IStudentQeustionsRepositroy
    {
        public StudentQeustionsRepositroy(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StudentQeustion>> GetBySubjectClassIdAsync(int subjectClassId)
        {
            return await _context.StudentQeustions.Include(s => s.Student).ThenInclude(s => s.User).Where(s => s.SubjectClassId == subjectClassId).ToListAsync();
        }

        public async Task<IEnumerable<TeacherAnswer>> GetteacherAnswerAsync(int id)
        {
            return await _context.TeacherAnswers.Include(t => t.StudentQeustion).ToListAsync();
        }
    }
}
