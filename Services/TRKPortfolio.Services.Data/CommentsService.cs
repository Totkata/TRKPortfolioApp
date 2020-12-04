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

        public CommentsService(
            IDeletableEntityRepository<Comment> commentRepo,
            IDeletableEntityRepository<Post> postRepo)
        {
            this.commentRepo = commentRepo;
            this.postRepo = postRepo;
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

        public Task ReplyAsync(CreateCommentInputModel inputModel, int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
