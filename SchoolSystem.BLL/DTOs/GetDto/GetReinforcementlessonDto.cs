﻿namespace SchoolSystem.BLL.DTOs.GetDto
{
    public class GetReinforcementlessonDto
    {
        public int ReinforcementlessonId { get; set; }

        public string ReinforcementlessonTitle { get; set; } = null!;

        public string? Reinforcementlessondescription { get; set; }

        public string? ReinforcementlessonFile { get; set; }

        public string? Reinforcementlessonlink { get; set; }

        public DateTime? ReinforcementlessonDate { get; set; }
    }


}
