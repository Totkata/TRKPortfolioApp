namespace TRKPortfolio.Web.ViewModels.Administration.Skills.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class SkillViewModel : IMapFrom<Skill>
    {
        public int Id { get; set; }

        public string SkillTitle { get; set; }
    }
}
