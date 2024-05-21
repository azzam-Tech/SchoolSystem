using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetTeacherEvaluationDto
    {
        public int TeacherEvaluationId { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        public decimal TeacherEvaluationValueOne { get; set; }

        public decimal TeacherEvaluationValueTow { get; set; }
    }


}
