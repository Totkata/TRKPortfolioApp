namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Categories.ViewModel;

    public interface ICategoriesService
    {
        Task CreateAsync(CreateCategoryInputModel input);

        IEnumerable<CategoryViewModel> GetAll();
    }
}
