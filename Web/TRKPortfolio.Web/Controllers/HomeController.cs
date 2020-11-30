namespace TRKPortfolio.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels;
    using TRKPortfolio.Web.ViewModels.Index.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.ViewModel;

    public class HomeController : BaseController
    {
        private readonly IProjectsService projectsService;

        public HomeController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Testimonials = this.projectsService.GetAll<TestimonialViewModel>(),
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
