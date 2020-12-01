namespace TRKPortfolio.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;
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
            };
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
