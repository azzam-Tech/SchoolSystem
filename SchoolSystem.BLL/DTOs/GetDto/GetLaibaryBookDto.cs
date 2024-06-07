namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetLaibaryBookDto
    {
        public int LaibaryBookId { get; set; }

        public int Sectionid { get; set; }

        public string LaibaryBookName { get; set; } = null!;

        public string? LaibaryBookImagePath { get; set; }

        public string LaibaryBookPath { get; set; } = null!;

    }

}
