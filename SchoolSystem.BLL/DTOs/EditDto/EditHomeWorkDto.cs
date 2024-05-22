namespace SchoolSystem.BLL.DTOs.EditDto
{
    public class EditHomeWorkDto
    {

        public decimal HomeWorkDegree { get; set; }

        public string HomeWorkTitle { get; set; } = null!;

        public string? HomeWorkdescription { get; set; }

        public string? HomeWorkText { get; set; }

        public string? HomeWorkImagePath { get; set; }

        public string? HomeWorkDeadline { get; set; }

    }
}
