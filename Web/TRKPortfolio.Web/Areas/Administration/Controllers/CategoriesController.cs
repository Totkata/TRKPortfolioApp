namespace TRKPortfolio.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.Areas.Administration.Controllers;
    using TRKPortfolio.Web.ViewModels.Administration.Categories;
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
            var vm = new AllCategoriesViewModel
            {
                Categories = this.categoriesService.GetAll().ToList(),
            };
            return this.View(vm);
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
