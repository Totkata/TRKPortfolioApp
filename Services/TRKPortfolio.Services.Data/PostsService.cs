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
    using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public PostsService(
            IDeletableEntityRepository<Post> postRepo,
            IDeletableEntityRepository<Category> categoryRepo)
        {
            this.postRepo = postRepo;
            this.categoryRepo = categoryRepo;
        }

        public async Task CreateAsync(CreatePostInputModel inputModel)
        {
            var post = new Post
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                Text = inputModel.Text,
            };

            foreach (var inputCategory in inputModel.Categories)
            {
                var category = this.categoryRepo.All().FirstOrDefault(x => x.Name == inputCategory.Name);

                if (category == null)
                {
                    category = new Category { Name = inputCategory.Name };
                }

                post.PostCategories.Add(new PostCategory
                {
                    Category = category,
                });
            }

            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
        }
    }
}
