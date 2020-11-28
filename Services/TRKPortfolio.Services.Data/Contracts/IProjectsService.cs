namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;
    using TRKPortfolio.Web.ViewModels.Projects.ViewModel;

    public interface IProjectsService
    {
        Task CreateAsync(CreateProjectInputModel inputModel);

        T GetById<T>(int id);

        IEnumerable<T> GetAll<T>();
    }
}
