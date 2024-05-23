namespace SchoolSystem.BLL.DTOs.EditDto
{
    public class EditSubjectClassDto
    {
        public int SubjectClassId { get; set; }

        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public int SubjectTeacher { get; set; }

        public string SubjectClassName { get; set; } = null!;
    }
}
