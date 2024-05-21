using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.BLL.DTOs.Students
{
    public class StudentDetailsDto
    {
        [StringLength(100)]
        public string StudentName { get; set; } = null!;

        [StringLength(20)]
        public string? Studentnumber { get; set; }

        [StringLength(50)]
        public string Studentpassword { get; set; } = null!;

        [StringLength(100)]
        public string? StudentImage { get; set; }

        [StringLength(100)]
        public string? StudentClass { get; set; }

        [StringLength(100)]
        public string? StudentParent { get; set; }

    }

}
