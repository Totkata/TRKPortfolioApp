namespace TRKPortfolio.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;
    using TRKPortfolio.Web.ViewModels.Administration.Projects.ViewModel;
    using TRKPortfolio.Web.ViewModels.Attachments.ViewModel;
    using TRKPortfolio.Web.ViewModels.Index.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.ViewModel;

    public class HomeController : BaseController
    {
        private readonly IProjectsService projectsService;
        private readonly IPostsService postsService;

        public HomeController(
            IProjectsService projectsService,
            IPostsService postsService)
        {
            this.projectsService = projectsService;
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Testimonials = this.projectsService.GetAllTestimonials<TestimonialViewModel>(),
                Posts = this.postsService.GetAllPosts<PostViewModel>(),
                Projects = this.projectsService.GetAll<ProjectViewModel>(),
            };

            foreach (var post in vm.Posts)
            {
                var thumbnail = this.postsService.GetThumbnail<PostAttachmentViewModel>(post.Id);

                if (thumbnail != null)
                {
                    var path = $"PostAttachments/{thumbnail.Id}.{thumbnail.Extention}";
                    post.Thumbnail = path;
                }
            }

            foreach (var post in vm.Projects)
            {
                var thumbnail = this.projectsService.GetThumbnail<ProjectAttachmentViewModel>(post.Id);

                if (thumbnail != null)
                {
                    var path = $"ProjectAttachments/{thumbnail.Id}.{thumbnail.Extention}";
                    post.Thumbnail = path;
                }
            }

            return this.View(vm);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
