namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Projects.ViewModel;

    public class ProjectsController : AdministrationController
    {
        private readonly IProjectsService projectsService;
        private readonly ICategoriesService categoriesService;
        private readonly ISkillsService skillsService;
        private readonly IUsersService usersService;
        private readonly IWebHostEnvironment environment;

        public ProjectsController(
            IProjectsService projectsService,
            ICategoriesService categoriesService,
            ISkillsService skillsService,
            IUsersService usersService,
            IWebHostEnvironment environment)
        {
            this.projectsService = projectsService;
            this.categoriesService = categoriesService;
            this.skillsService = skillsService;
            this.usersService = usersService;
            this.environment = environment;
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

            await this.projectsService.CreateAsync(input, $"{this.environment.WebRootPath}/images");

            return this.Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            var project = this.projectsService.GetById<ProjectViewModel>(id);

            var title = project.Title;
            var description = project.Description;

            var sb = new StringBuilder();

            foreach (var paragraph in project.Paragraphs)
            {
                sb.AppendLine(paragraph.ParagraphTitle);
                sb.AppendLine(paragraph.ParagraphContent);
                sb.AppendLine();
            }

            var text = sb.ToString();

            var viewModel = new EditProjectInputModel();
            viewModel.Title = title;
            viewModel.Description = description;
            viewModel.Text = text;
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
