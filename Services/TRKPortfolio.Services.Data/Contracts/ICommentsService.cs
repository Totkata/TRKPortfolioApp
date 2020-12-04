namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Comments.InputModel;

    public interface ICommentsService
    {
        Task CreateAsync(CreateCommentInputModel inputModel);

        Task ReplyAsync(CreateCommentInputModel inputModel, int commentId);
    }
}
