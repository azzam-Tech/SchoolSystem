namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostReinforcementlessonDto
    {
        public int SubjectClassId { get; set; }

        public int TermId { get; set; }

        public string ReinforcementlessonTitle { get; set; } = null!;

        public string? Reinforcementlessondescription { get; set; }

        public string? ReinforcementlessonFile { get; set; }

        public string? Reinforcementlessonlink { get; set; }

        public DateTime? ReinforcementlessonDate { get; set; }
    }

}
