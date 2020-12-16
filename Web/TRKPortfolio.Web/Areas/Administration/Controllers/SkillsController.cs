namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.ViewModel;

    public class SkillsController : AdministrationController
    {
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        public IActionResult Skills()
        {
            var viewModel = new AllSkillsViewModel
            {
                Skills = this.skillsService.GetAll().ToList(),
            };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.skillsService.CreateAsync(inputModel);

            return this.Redirect("/");
        }
    }
}
