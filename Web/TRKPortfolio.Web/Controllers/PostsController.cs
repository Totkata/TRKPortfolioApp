namespace TRKPortfolio.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;
    using TRKPortfolio.Web.ViewModels.Posts.InputModel;
    using TRKPortfolio.Web.ViewModels.Posts.ViewModel;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            var vm = new PostListViewModel
            {
                Posts = this.postsService.GetAllPosts<PostViewModel>(),
            };
            return this.View(vm);
        }

        public IActionResult Detail(int id)
        {
            var vm = new PostCommentInputModel
            {
                Post = this.postsService.GetById<PostViewModel>(id),
            };

            if (vm.Post == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(vm);
        }
    }
}
