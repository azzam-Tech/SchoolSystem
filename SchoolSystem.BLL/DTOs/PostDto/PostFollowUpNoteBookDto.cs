namespace SchoolSystem.BLL.DTOs.PostDto
{
    public class PostFollowUpNoteBookDto
    {
        public int SubjectClassId { get; set; }

        public int ClassId { get; set; }

        public int TermId { get; set; }

        public string FollowUpNoteBookText { get; set; } = null!;

        public DateTime FollowUpNoteBookDate { get; set; }
    }

}
