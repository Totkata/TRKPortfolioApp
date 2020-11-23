namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;

    public interface IProjectsService
    {
        Task CreateAsync(CreateProjectInputModel inputModel);
    }
}
