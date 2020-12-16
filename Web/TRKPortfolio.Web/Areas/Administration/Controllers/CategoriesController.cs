namespace TRKPortfolio.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.Areas.Administration.Controllers;
    using TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Categories.ViewModel;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Categories()
        {
            var viewModel = new AllCategoriesViewModel
            {
                Categories = this.categoriesService.GetAll().ToList(),
            };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoriesService.CreateAsync(inputModel);

            return this.Redirect("/Administration/Categories/Categories");
        }
    }
}
