namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetHomeWorkDto
    {
        public int SubjectClassId { get; set; }

        public int TermId { get; set; }

        public decimal HomeWorkDegree { get; set; }

        public string HomeWorkTitle { get; set; } = null!;

        public string? HomeWorkdescription { get; set; }

        public string? HomeWorkText { get; set; }

        public string? HomeWorkImagePath { get; set; }

        public string? HomeWorkDeadline { get; set; }

        public DateTime? HomeWorkDate { get; set; }
    }


}
