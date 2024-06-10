namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetStudentSuggestionDto
    {
        public int StudentSuggestionId { get; set; }

        public int StudentId { get; set; }

        //public int ClassId { get; set; }

        public string? StudentName { get; set; }

        public string? StudentSuggestionText { get; set; }


        public DateTime? StudentSuggestionDate { get; set; }

    }


}
