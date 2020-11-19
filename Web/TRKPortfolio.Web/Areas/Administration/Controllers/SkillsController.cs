namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.ViewModel;
    using TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel;

    public class SkillsController : AdministrationController
    {
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        public IActionResult Skills()
        {
            var vm = new AllSkillsViewModel
            {
                Skills = this.skillsService.GetAll().ToList(),
            };
            return this.View(vm);
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
