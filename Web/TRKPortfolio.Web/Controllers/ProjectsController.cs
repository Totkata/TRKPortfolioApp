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
    using TRKPortfolio.Web.ViewModels.Administration.Projects.ViewModel;
    using TRKPortfolio.Web.ViewModels.Attachments.ViewModel;
    using TRKPortfolio.Web.ViewModels.Projects.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.InputModel;

    public class ProjectsController : BaseController
    {
        private readonly IProjectsService projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public IActionResult Index()
        {
            var viewModel = new ProjectListViewModel
            {
                Projects = this.projectsService.GetAll<ProjectViewModel>(),
            };

            foreach (var post in viewModel.Projects)
            {
                var thumbnail = this.projectsService.GetThumbnail<ProjectAttachmentViewModel>(post.Id);

                if (thumbnail != null)
                {
                    var path = $"ProjectAttachments/{thumbnail.Id}.{thumbnail.Extention}";
                    post.Thumbnail = path;
                }
            }

            return this.View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var vm = new ProjectAttatchmentListViewModel { };

            vm.Project = this.projectsService.GetById<ProjectViewModel>(id);

            if (vm.Project == null)
            {
                return this.RedirectToAction("Index");
            }

            var attachments = this.projectsService.GetAllAttachments<ProjectAttachmentViewModel>(id);

            var paths = new List<string>();

            foreach (var attachment in attachments)
            {
                paths.Add($"ProjectAttachments/{attachment.Id}.{attachment.Extention}");
            }

            vm.Attachments = paths;

            return this.View(vm);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateTestimonialInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.projectsService.AddTestimonialAsyncAsync(input);

            return this.Redirect("/");
        }
    }
}
