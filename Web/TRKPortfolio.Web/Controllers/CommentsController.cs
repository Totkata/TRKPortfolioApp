namespace TRKPortfolio.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Posts.InputModel;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input.Comment);
            }

            await this.commentsService.CreateAsync(input.Comment);
            return this.RedirectToAction("Detail", "Posts", new { id = input.Comment.PostId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Reply(PostCommentInputModel input, int commentId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input.Comment);
            }

            await this.commentsService.ReplyAsync(input.Comment, commentId);
            return this.RedirectToAction("Detail", "Posts", new { id = input.Comment.PostId });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            int postId = await this.commentsService.RemoveAsync(id);

            return this.RedirectToAction("Detail", "Posts", new { id = postId});
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReply(int id)
        {
            int postId = await this.commentsService.RemoveReplyAsync(id);

            return this.RedirectToAction("Detail", "Posts", new { id = postId });
        }
    }
}
