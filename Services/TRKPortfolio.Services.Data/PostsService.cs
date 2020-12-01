namespace TRKPortfolio.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;
        private readonly IDeletableEntityRepository<Paragraph> paragraphRepo;

        public PostsService(
            IDeletableEntityRepository<Post> postRepo,
            IDeletableEntityRepository<Category> categoryRepo,
            IDeletableEntityRepository<Paragraph> paragraphRepo)
        {
            this.postRepo = postRepo;
            this.categoryRepo = categoryRepo;
            this.paragraphRepo = paragraphRepo;
        }

        public async Task CreateAsync(CreatePostInputModel inputModel)
        {
            StringBuilder sb = new StringBuilder();

            int maxLenght = inputModel.Description.Length > 75 ? 75 : inputModel.Description.Length;
            sb.Append(inputModel.Description.Substring(0, maxLenght));
            sb.Append("...");

            var post = new Post
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                ShortDescription = sb.ToString(),
            };

            foreach (var inputCategory in inputModel.CategoryId)
            {
                var category = this.categoryRepo.All().FirstOrDefault(x => x.Id == inputCategory);

                post.PostCategories.Add(new PostCategory
                {
                    Category = category,
                });
            }

            // ToDo Make better paragraph splitting
            var splitedInput = inputModel.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedInput.Length; i += 2)
            {
                post.Paragraphs.Add(new PostParagraph
                {
                    Paragraph = new Paragraph
                    {
                        Title = splitedInput[i],
                        Content = splitedInput[i + 1],
                    },
                });
            }

            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
        }

        // TODO DA MU EBA MAMATA OPRAVI GO TOVA
        public IEnumerable<T> GetAllPosts<T>()
        {
            var posts = this.postRepo.AllAsNoTracking()
               .To<T>().ToList();
            return posts;
        }
    }
}
