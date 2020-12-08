namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        public string SkillTitle { get; set; }
    }
}
