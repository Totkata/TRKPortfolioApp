namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel;

    public interface ICategoriesService
    {
        Task CreateAsync(CreateCategoryInputModel input);
    }
}
