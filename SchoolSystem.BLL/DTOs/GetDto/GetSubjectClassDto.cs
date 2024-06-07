using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetSubjectClassDto
    {
        public int SubjectClassId { get; set; }

        public int LevelId { get; set; }
        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public int SubjectTeacher { get; set; }

        public string SubjectClassName { get; set; } = null!;
        public string? SubjectClassImage{ get; set; }
    }






}
