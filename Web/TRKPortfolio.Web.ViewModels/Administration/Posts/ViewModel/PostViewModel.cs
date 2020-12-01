namespace TRKPortfolio.Web.ViewModels.Administration.Posts.ViewModel
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.Views.Paragraphs.ViewModel;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public IEnumerable<ParagraphsViewModel> Paragraphs { get; set; }
    }
}
