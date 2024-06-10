namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetStudentDegreeDto
    {

        public int StudentDegreeId { get; set; }

        public decimal? StudentDegreeValue { get; set; }

        public string? StudentName { get; set; }

    }

    public class GetStudentDegreeforSuperDto
    {

        public int StudentDegreeId { get; set; }

        public int DegreeTypeId { get; set; }

        public decimal? StudentDegreeValue { get; set; }

        public string? StudentName { get; set; }

    }


    public class GetStudentDegreeformanagerDto
    {

        public decimal? StudentDegreeValue { get; set; }

        public string? StudentName { get; set; }

    }
}
