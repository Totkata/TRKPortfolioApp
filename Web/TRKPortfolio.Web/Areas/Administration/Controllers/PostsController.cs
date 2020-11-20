using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRKPortfolio.Services.Data.Contracts;
using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;

namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    public class PostsController : AdministrationController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.postsService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
