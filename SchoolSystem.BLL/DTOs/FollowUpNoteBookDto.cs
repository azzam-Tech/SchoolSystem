using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs
{
    public class FollowUpNoteBookDto
    {
        public int FollowUpNoteBookId { get; set; }

        public int SubjectClassId { get; set; }

        public int ClassId { get; set; }

        public int TermId { get; set; }

        public string FollowUpNoteBookText { get; set; } = null!;

        public DateTime FollowUpNoteBookDate { get; set; }
    }
}
