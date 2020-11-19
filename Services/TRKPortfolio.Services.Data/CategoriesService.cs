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
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel;
    using TRKPortfolio.Web.ViewModels.Administration.Categories.ViewModel;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(CreateCategoryInputModel input)
        {
            var categoryExists = this.categoryRepository
                .AllAsNoTracking()
                .Any(x => x.Name == input.Name);

            if (!categoryExists)
            {
                var category = new Category
                {
                    Name = input.Name,
                };

                await this.categoryRepository.AddAsync(category);
                await this.categoryRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.categoryRepository.AllAsNoTracking().To<CategoryViewModel>().ToList();
            return categories;
        }
    }
}
