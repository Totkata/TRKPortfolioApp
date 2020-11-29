namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;

    public class ProjectsController : AdministrationController
    {
        private readonly IProjectsService projectsService;
        private readonly ICategoriesService categoriesService;
        private readonly ISkillsService skillsService;
        private readonly IUsersService usersService;

        public ProjectsController(
            IProjectsService projectsService,
            ICategoriesService categoriesService,
            ISkillsService skillsService,
            IUsersService usersService)
        {
            this.projectsService = projectsService;
            this.categoriesService = categoriesService;
            this.skillsService = skillsService;
            this.usersService = usersService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProjectInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            viewModel.Skills = this.skillsService.GetAllAsKeyValuePairs();
            viewModel.Customers = this.usersService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.projectsService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult Edit()
        {
            var viewModel = new EditProjectInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            viewModel.Skills = this.skillsService.GetAllAsKeyValuePairs();
            viewModel.Customers = this.usersService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.projectsService.EditAsync(input);

            return this.Redirect("/");
        }
    }
}
