namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel;

    public interface ISkillsService
    {
        Task CreateAsync(CreateSkillInputModel input);
    }
}
