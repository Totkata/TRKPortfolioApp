namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;

    public interface IPostsService
    {
        Task CreateAsync(CreatePostInputModel inputModel);

        IEnumerable<T> GetAllPosts<T>();
    }
}
