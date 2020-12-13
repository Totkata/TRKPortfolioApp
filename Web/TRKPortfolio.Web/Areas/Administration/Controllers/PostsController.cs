namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;

    public class PostsController : AdministrationController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly IWebHostEnvironment environment;
        private readonly ICommentsService commentsService;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            IWebHostEnvironment environment,
            ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.environment = environment;
            this.commentsService = commentsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePostInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.postsService.CreateAsync(input, $"{this.environment.WebRootPath}/images");

            return this.Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            var project = this.postsService.GetById<PostViewModel>(id);

            var title = project.Title;
            var description = project.Description;
            var paragraphs = project.Paragraphs;

            var viewModel = new EditPostInputModel();
            viewModel.Title = title;
            viewModel.Description = description;
            viewModel.ParagraphsVm = paragraphs;
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.postsService.EditAsync(input);

            return this.Redirect("/");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.postsService.RemoveAsync(id);

            return this.RedirectToAction("Detail", "Posts", new { area = string.Empty });
        }
    }
}
