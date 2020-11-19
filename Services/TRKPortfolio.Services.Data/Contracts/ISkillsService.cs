namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.ViewModel;

    public interface ISkillsService
    {
        Task CreateAsync(CreateSkillInputModel input);

        IEnumerable<SkillViewModel> GetAll();
    }
}
