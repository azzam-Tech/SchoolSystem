using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Interfaces.Abstracts
{
    public interface IStudentDegreesRepositroy : IBaseRepository<StudentDegree>
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<IEnumerable<DegreeType>> GetAllDegreeType();
        Task<IEnumerable<SubjectClass>> GetAllSubjectClass();
        Task<IEnumerable<StudentDegree>> GetBySbjectClassIdandDegreeTypeId(int sbjectClassId, int degreeTypeId);
        Task<IEnumerable<StudentDegree>> GetStudentDegreesByStudentId(int studentId);
        Task<IEnumerable<StudentDegree>> GetByStudentIdandDegreeTypeId(int studentId);
        Task<IEnumerable<StudentDegree>> GetBySbjectClassId(int sbjectClassId);
    }
}
