namespace TRKPortfolio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Comments.InputModel;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepo;
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IDeletableEntityRepository<Reply> replyRepo;

        public CommentsService(
            IDeletableEntityRepository<Comment> commentRepo,
            IDeletableEntityRepository<Post> postRepo,
            IDeletableEntityRepository<Reply> replyRepo)
        {
            this.commentRepo = commentRepo;
            this.postRepo = postRepo;
            this.replyRepo = replyRepo;
        }

        public async Task CreateAsync(CreateCommentInputModel inputModel)
        {
            var post = this.postRepo.AllAsNoTracking()
                .Where(x => x.Id == inputModel.PostId)
                .FirstOrDefault();

            var comment = new Comment
            {
                Text = inputModel.Text,
                PostId = inputModel.PostId,
            };

            post.Comments.Add(comment);
            await this.postRepo.SaveChangesAsync();

            await this.commentRepo.AddAsync(comment);
            await this.commentRepo.SaveChangesAsync();
        }

        public async Task ReplyAsync(CreateCommentInputModel inputModel, int commentId)
        {
            var comment = this.postRepo.AllAsNoTracking()
                .Where(x => x.Id == inputModel.PostId)
                .Select(x => x.Comments.Where(x => x.Id == inputModel.CommentId).FirstOrDefault())
                .FirstOrDefault();

            var reply = new Reply
            {
                Text = inputModel.Text,
                PostId = inputModel.PostId,
                CommentId = inputModel.CommentId,
            };

            comment.Replies.Add(reply);
            await this.commentRepo.SaveChangesAsync();

            await this.replyRepo.AddAsync(reply);
            await this.replyRepo.SaveChangesAsync();
        }
    }
}
