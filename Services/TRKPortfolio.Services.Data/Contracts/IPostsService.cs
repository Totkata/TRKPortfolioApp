namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;

    public interface IPostsService
    {
        Task<int> CreateAsync(CreatePostInputModel inputModel, string filePatch);

        Task<int> EditAsync(EditPostInputModel inputModel);

        Task RemoveAsync(int id);

        IEnumerable<T> GetAllPosts<T>();

        T GetById<T>(int id);

        T GetThumbnail<T>(int id);
    }
}
