namespace TRKPortfolio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;
        private readonly IDeletableEntityRepository<PostAttachment> attachmentRepo;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "pdf" };

        public PostsService(
            IDeletableEntityRepository<Post> postRepo,
            IDeletableEntityRepository<Category> categoryRepo,
            IDeletableEntityRepository<PostAttachment> attachmentRepo)
        {
            this.postRepo = postRepo;
            this.categoryRepo = categoryRepo;
            this.attachmentRepo = attachmentRepo;
        }

        public async Task CreateAsync(CreatePostInputModel inputModel, string filePath)
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

            foreach (var paragraph in inputModel.Paragraphs)
            {
                var paragraphFileExtension = Path.GetExtension(inputModel.Thumbnail.FileName).TrimStart('.').ToLower();
                if (!this.allowedExtensions.Any(x => paragraphFileExtension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {paragraphFileExtension}");
                }

                var dbParagraphFile = new ParagraphAttachment
                {
                    Extention = paragraphFileExtension,
                };

                var paragraphPhysicalPath = $"{filePath}/PostAttachments/ParagraphsAttachments/{dbParagraphFile.Id}.{paragraphFileExtension}";

                post.Paragraphs.Add(new PostParagraph
                {
                    Paragraph = new Paragraph
                    {
                        Title = paragraph.Title,
                        Content = paragraph.Content,
                        Attachment = dbParagraphFile,
                        Path = $"/PostAttachments/ParagraphsAttachments/{dbParagraphFile.Id}.{paragraphFileExtension}",
                    },
                });

                using Stream paragraphFileStream = new FileStream(paragraphPhysicalPath, FileMode.Create);
                await paragraph.Attachment.CopyToAsync(paragraphFileStream);
            }

            var extension = Path.GetExtension(inputModel.Thumbnail.FileName).TrimStart('.').ToLower();
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var dbFile = new PostAttachment
            {
                Extention = extension,
            };
            post.Attachments.Add(dbFile);

            var physicalPath = $"{filePath}/PostAttachments/{dbFile.Id}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.CreateNew);
            await inputModel.Thumbnail.CopyToAsync(fileStream);

            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var post = await this.postRepo.GetByIdWithDeletedAsync(id);

            this.postRepo.Delete(post);

            await this.postRepo.SaveChangesAsync();
        }

        public T GetThumbnail<T>(int id)
        {
            var thumbnail = this.attachmentRepo.AllAsNoTracking()
                .Where(x => x.PostId == id)
               .To<T>().FirstOrDefault();
            return thumbnail;
        }

        public IEnumerable<T> GetAllPosts<T>()
        {
            var posts = this.postRepo.AllAsNoTracking()
               .To<T>().ToList();
            return posts;
        }

        public T GetById<T>(int id)
        {
            var post = this.postRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return post;
        }

        public async Task EditAsync(EditPostInputModel inputModel)
        {
            var post = this.postRepo
               .All()
               .Include(p => p.Paragraphs)
               .ThenInclude(p => p.Paragraph)
               .Include(p => p.PostCategories)
               .ThenInclude(p => p.Category)
               .FirstOrDefault(x => x.Id == inputModel.Id);

            post.Title = inputModel.Title;
            post.Description = inputModel.Description;

            post.Paragraphs.Clear();
            foreach (var paragraph in inputModel.Paragraphs)
            {
                post.Paragraphs.Add(new PostParagraph
                {
                    Paragraph = new Paragraph
                    {
                        Title = paragraph.Title,
                        Content = paragraph.Content,
                    },
                });
            }

            post.Description = inputModel.Description;
            post.ShortDescription = ShortDescriptionParser(inputModel.Description);

            post.PostCategories.Clear();
            CategoriesHandeller(inputModel.CategoryId, post, this.categoryRepo);

            await this.postRepo.SaveChangesAsync();
        }

        private static void ParagraphParser(string input, Post post)
        {
            var splitedInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

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
        }

        private static string ShortDescriptionParser(string input)
        {
            StringBuilder sb = new StringBuilder();

            int maxLenght = input.Length > 75 ? 75 : input.Length;
            sb.Append(input.Substring(0, maxLenght));
            sb.Append("...");

            return sb.ToString();
        }

        private static void CategoriesHandeller(int[] input, Post post, IDeletableEntityRepository<Category> categoryRepo)
        {
            foreach (var inputCategory in input)
            {
                var category = categoryRepo.All().FirstOrDefault(x => x.Id == inputCategory);

                post.PostCategories.Add(new PostCategory
                {
                    Category = category,
                });
            }
        }
    }
}
