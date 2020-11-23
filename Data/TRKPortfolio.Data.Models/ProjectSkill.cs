namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectSkill
    {
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
