using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.Abstracts;
using SchoolSystem.DAL.Interfaces.BaseRepository;

namespace SchoolSystem.DAL.Interfaces.Implementations
{
    public class TeacherEvaluationsRepository : BaseRepository<TeacherEvaluation>, ITeacherEvaluationsRepository
    {
        public TeacherEvaluationsRepository(AppDbContext context) : base(context)
        {
        }

        //public async Task<IEnumerable <User>> CraeateAll()
        //{
        //    return await _context.Users.Where( u => u.RoleId == 4 ).ToListAsync();  


        //}

        public async Task CraeateAll()
        {
            var xx = await _context.Users.Where(u => u.RoleId == 4).Select(u => new { u.UserId }).ToListAsync();
            var yy = new List<TeacherEvaluation>();
            foreach (var x in xx)
            {
                var y = new TeacherEvaluation
                {
                    UserId = x.UserId,
                    TeacherEvaluationValueOne = 0,
                    TeacherEvaluationValueTow = 0
                };
                yy.Add(y);

            }
            await _context.TeacherEvaluations.AddRangeAsync(yy);    
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<TeacherEvaluation>> GetAllwithnameAsync()
        {
            return await _context.TeacherEvaluations.Include(u => u.User).ToListAsync();
           
           
            //throw new NotImplementedException();
        }

        public async  Task<TeacherEvaluation> GetByTeacherIdAsync(int teacherId)
        {
            return await _context.TeacherEvaluations.Include(u => u.User).FirstOrDefaultAsync(t => t.UserId == teacherId);
        }

    }
}