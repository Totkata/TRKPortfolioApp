namespace TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel
{
    using System.Collections.Generic;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.Views.Paragraphs.ViewModel;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public IEnumerable<PostParagraphViewModel> Paragraphs { get; set; }

        public string Thumbnail { get; set; }
    }
}
