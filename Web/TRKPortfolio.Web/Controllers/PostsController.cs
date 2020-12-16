namespace TRKPortfolio.Web.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel;
    using TRKPortfolio.Web.ViewModels.Attachments.ViewModel;
    using TRKPortfolio.Web.ViewModels.Comments.ViewModel;
    using TRKPortfolio.Web.ViewModels.Posts.InputModel;
    using TRKPortfolio.Web.ViewModels.Posts.ViewModel;

    public class PostsController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly ICommentsService commentsService;

        public PostsController(
            IPostsService postsService,
            ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.commentsService = commentsService;
        }

        public IActionResult Index()
        {
            var vm = new PostListViewModel
            {
                Posts = this.postsService.GetAllPosts<PostViewModel>(),
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

            return this.View(vm);
        }

        public IActionResult Detail(int id)
        {
            var viewModel = new PostCommentInputModel
            {
                Post = this.postsService.GetById<PostViewModel>(id),
                Comments = this.commentsService.GetAllPostComments<CommentViewModel>(id),
            };

            if (viewModel.Post == null)
            {
                return this.RedirectToAction("Index");
            }

            var attachment = this.postsService.GetThumbnail<PostAttachmentViewModel>(id);

            var path = $"PostAttachments/{attachment.Id}.{attachment.Extention}";

            viewModel.Post.Thumbnail = path;

            return this.View(viewModel);
        }
    }
}
