namespace TRKPortfolio.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Projects.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.InputModel;

    public class ProjectsController : BaseController
    {
        private readonly IProjectsService projectsService;
        private readonly ITestimonialsService testimonialsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(
            IProjectsService projectsService,
            ITestimonialsService testimonialsService,
            UserManager<ApplicationUser> userManager)
        {
            this.projectsService = projectsService;
            this.testimonialsService = testimonialsService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var viewModel = new ProjectListViewModel
            {
                Projects = this.projectsService.GetAll<ProjectViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var project = this.projectsService.GetById<ProjectViewModel>(id);

            if (project == null)
            {
                return this.RedirectToAction("Index");
            }

            if (project.ApplicationUserId == this.userManager.GetUserId(this.User).ToString())
            {
                return this.RedirectToAction("Create");
            }

            return this.View(project);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialInputModel input, int id)
        {
            var project = this.projectsService.GetById<Project>(id);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.testimonialsService.CreateAsync(input, project);

            return this.Redirect("/");
        }
    }
}
