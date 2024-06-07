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
    public class StudentDegreesRepositroy : BaseRepository<StudentDegree> , IStudentDegreesRepositroy
    {
        public StudentDegreesRepositroy(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();   
        }

        public async Task<IEnumerable<DegreeType>> GetAllDegreeType()
        {
            return await _context.DegreeTypes.ToListAsync();
        }

        public async Task<IEnumerable<SubjectClass>> GetAllSubjectClass()
        {
            return await _context.SubjectClasses.ToListAsync();
        }

        public async Task<IEnumerable<StudentDegree>> GetBySbjectClassIdandDegreeTypeId(int sbjectClassId, int degreeTypeId)
        {
            return await _context.StudentDegrees.Include(u => u.Student).ThenInclude( uu => uu.User ).Where(x => x.SubjectClassId == sbjectClassId && x.DegreeTypeId == degreeTypeId).ToListAsync(); 
        }

        public async Task<IEnumerable<StudentDegree>> GetStudentDegreesByStudentId(int studentId)
        {
            //    _context.StudentDegrees
            //        .Join(_context.SubjectClass, sd => sd.SubjectClassId, subject => subject.Id, (sd, subject) => new
            //        {
            //            StudentDegreeValue = sd.StudentDegreeValue,
            //            StudentDegreeNots = sd.StudentDegreeNots,
            //            SubjectName = subject.Name
            //        })
            //        .ToListAsync();

            //_context.StudentDegrees
            //       .Include(sd => sd.SubjectClass)
            //       .Select(
            //             c => new
            //             {
            //                 St
            //             }
            //                  )
            //       .ToListAsync();

            //select StudentDegreeValue and StudentDegreenots from StudentDegrees where StudentId = studentId
            //return Task.FromResult(_context.StudentDegrees.Where(x => x.StudentId == studentId).AsEnumerable());


            var studentDegrees = await _context.StudentDegrees
            .Include(sd => sd.SubjectClass)
            .Where(x => x.StudentId == studentId)
            .ToListAsync();

            // Process the data after fetching
            //var studentDegreeData = studentDegrees.Select(sd => new
            //{
            //    StudentDegreeValue = sd.StudentDegreeValue,
            //    StudentDegreeNots = sd.StudentDegreenote,
            //    SubjectName = sd.SubjectClass?.SubjectClassName // Access Subject.Name if Subject exists (null-conditional operator)
            //});


            return studentDegrees;


        }

        public async Task<IEnumerable<StudentDegree>> GetByStudentIdandDegreeTypeId(int studentId, int degreeTypeId)
        {
            return await _context.StudentDegrees.Include(s => s.SubjectClass).ThenInclude( ss => ss.Subject).Where(s => s.StudentId == studentId && s.DegreeTypeId == degreeTypeId).ToListAsync();
        }

        public async Task<IEnumerable<StudentDegree>> GetBySbjectClassId(int sbjectClassId)
        {
            return await _context.StudentDegrees.Include(u => u.Student).ThenInclude(uu => uu.User).Where(x => x.SubjectClassId == sbjectClassId ).ToListAsync();
        }
    }
}
