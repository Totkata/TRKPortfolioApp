namespace TRKPortfolio.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
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

            foreach (var project in viewModel.Projects)
            {
                var thumbnail = this.projectsService.GetThumbnail<ProjectAttachmentViewModel>(project.Id);

                if (thumbnail != null)
                {
                    var path = $"ProjectAttachments/{thumbnail.Id}.{thumbnail.Extention}";
                    project.Thumbnail = path;
                }
            }

            return this.View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var viewModel = this.projectsService.GetById<ProjectViewModel>(id);

            if (viewModel == null)
            {
                return this.RedirectToAction("Index");
            }

            var thumbnail = this.projectsService.GetThumbnail<ProjectAttachmentViewModel>(id);

            var path = $"ProjectAttachments/{thumbnail.Id}.{thumbnail.Extention}";

            viewModel.Thumbnail = path;

            return this.View(viewModel);
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

            return this.RedirectToAction("Detail", "Projects", new { input.Id, area = string.Empty });
        }

        public IActionResult Edit(int id)
        {
            var viewModel = new CreateTestimonialInputModel { };

            viewModel.CurrentTestimonial = this.projectsService.GetTestimonialByProjectId(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateTestimonialInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.projectsService.EditTestimonial(input);

            return this.RedirectToAction("Detail", "Projects", new { input.Id, area = string.Empty });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var projectId = await this.projectsService.RemoveTestimonialAsync(id);

            return this.RedirectToAction("Detail", "Projects", new { projectId, area = string.Empty });
        }
    }
}
