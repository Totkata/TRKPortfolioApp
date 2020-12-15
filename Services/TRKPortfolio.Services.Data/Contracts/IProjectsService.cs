namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;
    using TRKPortfolio.Web.ViewModels.Projects.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.InputModel;

    public interface IProjectsService
    {
        Task<int> CreateAsync(CreateProjectInputModel inputModel, string filePatch);

        Task<int> EditAsync(EditProjectInputModel inputModel);

        Task RemoveAsync(int id);

        Task AddTestimonialAsyncAsync(CreateTestimonialInputModel inputModel);

        Task EditTestimonial(CreateTestimonialInputModel inputModel);

        Task<int> RemoveTestimonialAsync(int id);

        T GetById<T>(int id);

        string GetTestimonialByProjectId(int id);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllTestimonials<T>();

        T GetThumbnail<T>(int id);
    }
}
